using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using Models;

namespace BaseService
{
    public class ApplicationSettingsConfiguration
    {
        public IEnumerable<ApplicationSetting> ApplicationSettingElements
        {
            get
            {
                foreach (ApplicationSetting applicationSetting in this.ApplicationSettings)
                {
                    if (applicationSetting != null)
                        yield return applicationSetting;
                }
            }
        }

        public ApplicationSetting GetApplicationSetting(string Name)
        {
            return this.ApplicationSettingElements.Where(s => s.Name == Name).First();
        }

        private ApplicationSettingsSection ApplicationSettingsConfigurationSection
        {
            get
            {
                return (ApplicationSettingsSection)ConfigurationManager.GetSection("Application");
            }
        }

        private ApplicationSettingCollection ApplicationSettings
        {
            get
            {
                return this.ApplicationSettingsConfigurationSection.ApplicationSettingsElement;
            }
        }

    }
}
