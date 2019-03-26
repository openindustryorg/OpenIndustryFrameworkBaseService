using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Models
{
    [ConfigurationCollection(typeof(Client))]
    public class ClientCollection : ConfigurationElementCollection
    {
        internal const string PropertyName = "Client";

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
            return new Client();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((Client)(element)).MachineId;
        }

        public Client this[int idx]
        {
            get
            {
                return (Client)BaseGet(idx);
            }
        }
    }
}
