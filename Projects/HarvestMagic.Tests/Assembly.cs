using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace HarvestMagic.Tests
{
    [TestClass]
    public class Assembly
    {
        [AssemblyInitialize]
        public static void BeforeAllTestsInAssembly(TestContext context)
        {
            ConfigureLogging();
        }

        /// <summary>
        /// Configures logging for this test assembly.
        /// </summary>
        /// <remarks>
        /// NLog.config file is not used because Visual Studio 2010 needs the test configuration set but
        /// that is not used in Visual Studio 2012.
        /// </remarks>
        private static void ConfigureLogging()
        {
            var configuration = LogManager.Configuration;

            if (configuration != null)
            {
                throw new InvalidOperationException(String.Format("NLog cannot be configured with an XML file, e.g. NLog.config. {0}.BeforeAllTestsInAssembly must be used.", typeof(Assembly)));
            }

            configuration = new LoggingConfiguration();

            AddChainsawLogging(configuration);

            LogManager.Configuration = configuration;
        }

        private static void AddChainsawLogging(LoggingConfiguration configuration)
        {
            const string TargetName = "Chainsaw";

            var target = new ChainsawTarget() { Name = TargetName, Address = "udp://127.0.0.1:7071" };
            var rule = new LoggingRule("*", LogLevel.Trace, target);

            configuration.AddTarget(TargetName, target);
            configuration.LoggingRules.Add(rule);
        }
    }
}
