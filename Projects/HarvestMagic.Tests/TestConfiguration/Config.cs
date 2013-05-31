using System;
using System.Linq;
using System.IO;
using YamlDotNet.RepresentationModel.Serialization;

namespace HarvestMagic.Tests.TestConfiguration
{
    public class Config
    {
        private static readonly Lazy<Config> _Instance = new Lazy<Config>(() => Config.Deserialize());

        public Config()
        {
            // todo: should be private but need to work out how to configure YamlDotNet.RepresentationModel.Serialization.Deserializer to handle it.
        }

        private static string ConfigFileName
        {
            get
            {
                var userFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                var configFileName = Path.Combine(userFolder, "TestConfiguration.yaml");

                return configFileName;
            }
        }

        public static Config Instance
        {
            get
            {
                return _Instance.Value;
            }
        }

        public HarvestAccount HarvestAccount { get; set; }

        private static Config Deserialize()
        {
            return Deserialize(ConfigFileName);
        }

        private static Config Deserialize(string configFileName)
        {
            if (!File.Exists(configFileName))
            {
                WriteSampleConfigFile(configFileName);
                throw new Exception(string.Format("Update the sample config file, {0}, before running tests.", configFileName));
            }
            using (var streamReader = File.OpenText(configFileName))
            {
                var deserializer = new Deserializer();
                return deserializer.Deserialize<Config>(streamReader);
            }
        }

        private static void WriteSampleConfigFile(string configFileName)
        {
            using (var streamWriter = File.CreateText(configFileName))
            {
                var serializer = new Serializer();
                serializer.Serialize(streamWriter, Config.SampleConfig());
            }
        }

        private static Config SampleConfig()
        {
            var config = new Config();

            config.HarvestAccount = new HarvestAccount() { Password = "sample password", Uri = "http://sample.com", UserName = "sample username" };

            return config;
        }
    }
}
