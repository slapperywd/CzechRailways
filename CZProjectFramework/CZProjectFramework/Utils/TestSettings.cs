using System;
using System.Configuration;

namespace CZProjectFramework.Utils
{
    public class TestSettings
    {
        public string BaseURL { get; set; }
        public string Language { get; set; }
        public string BrowserName { get; set; }
        public int ImplicitTimeout { get; set; }
        public string NadaPage { get; set; }
        public string Domain { get; set; }

        /// <summary>
        ///     Gets variable value from App.config by its key name
        /// </summary>
        /// <param name="key">key name</param>
        /// <returns>value associated with key</returns>
        private string Get(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public TestSettings()
        {
            BaseURL = Get("baseURL");
            Language = Get("language");
            BrowserName = Get("browserName");
            ImplicitTimeout = Convert.ToInt32(Get("implicitTimeout"));
            NadaPage = Get("nadaPage");
            Domain = Get("domain");
        }
    }
}
