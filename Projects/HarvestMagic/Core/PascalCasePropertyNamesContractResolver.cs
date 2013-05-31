using Newtonsoft.Json.Serialization;
using NLog;
using System.Text;

namespace HarvestMagic.Core
{
    /// <summary>
    /// Used by <see cref="T:Newtonsoft.Json.JsonSerializer"/> to convert pascal case property names (e.g. CacheVersion) to 
    /// JSON property names (e.g. Cache_Version).
    /// </summary>
    public class PascalCasePropertyNamesContractResolver : DefaultContractResolver
    {
        private readonly Logger log = LogManager.GetCurrentClassLogger();

        public PascalCasePropertyNamesContractResolver()
            : base(true)
        {
        }

        protected override string ResolvePropertyName(string propertyName)
        {
            var pascalValue = new StringBuilder(propertyName.Substring(0,1));
            
            for (int i = 1; i < propertyName.Length; i++)
            {
                char character = propertyName[i];

                if (char.IsUpper(character))
                {
                    pascalValue.Append("_");
                }

                pascalValue.Append(character);
            }

            log.Debug("ResolvePropertyName({0}), pascalValue: {1}", propertyName, pascalValue);

            return pascalValue.ToString();
        }
    }
}
