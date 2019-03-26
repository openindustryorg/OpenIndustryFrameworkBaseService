using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Models
{
public class ApplicationSetting : ConfigurationElement
{
    [ConfigurationProperty("Name", DefaultValue = "", IsKey = true, IsRequired = true)]
    public string Name
        {
        get { return (string)base["Name"]; }
        set { base["Name"] = value; }
    }
    [ConfigurationProperty("Description", DefaultValue = "", IsKey = false, IsRequired = true)]
    public string Description
        {
        get { return (string)base["Description"]; }
        set { base["Description"] = value; }
    }

    [ConfigurationProperty("Value", DefaultValue = "", IsKey = false, IsRequired = false)]
    public string Value
        {
        get { return (string)base["Value"]; }
        set { base["Value"] = value; }
    }
}
}
