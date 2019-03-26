using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Models
{
    [ConfigurationCollection(typeof(ApplicationSetting))]
    public class ApplicationSettingCollection : ConfigurationElementCollection
    {
        internal const string PropertyName = "ApplicationSetting";

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMapAlternate;
            }
        }
        protected override string ElementName
        {
            get
            {
                return PropertyName;
            }
        }

        protected override bool IsElementName(string elementName)
        {
            return elementName.Equals(PropertyName, StringComparison.InvariantCultureIgnoreCase);
        }


        public override bool IsReadOnly()
        {
            return false;
        }


        protected override ConfigurationElement CreateNewElement()
        {
            return new ApplicationSetting();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ApplicationSetting)(element)).Name;
        }

        public ApplicationSetting this[int idx]
        {
            get
            {
                return (ApplicationSetting)BaseGet(idx);
            }
        }
    }
}
