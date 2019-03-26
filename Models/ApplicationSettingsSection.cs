using System.Configuration;

namespace Models
{
    public class ApplicationSettingsSection : ConfigurationSection
    {
        [ConfigurationProperty("ApplicationSettings")]
        public ApplicationSettingCollection ApplicationSettingsElement
        {
            get { return ((ApplicationSettingCollection)(base["ApplicationSettings"])); }
            set { base["ApplicationSettings"] = value; }
        }
        
    }
}
