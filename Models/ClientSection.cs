using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Models
{
    public class ClientSection : ConfigurationSection
    {
        [ConfigurationProperty("ClientSettings")]
        public ClientCollection ClientsElement
        {
            get { return ((ClientCollection)(base["ClientSettings"])); }
            set { base["ClientSettings"] = value; }
        }
    }
}
