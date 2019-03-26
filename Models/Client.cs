using System.Configuration;

namespace Models
{
    public class Client : ConfigurationElement
    {
        [ConfigurationProperty("MachineId", DefaultValue = "", IsKey = false, IsRequired = true)]
        public string MachineId
        {
            get { return (string)base["MachineId"]; }
            set { base["MachineId"] = value; }
        }
        [ConfigurationProperty("MachineName", DefaultValue = "", IsKey = true, IsRequired = true)]
        public string MachineName
        {
            get { return (string)base["MachineName"]; }
            set { base["MachineName"] = value; }
        }

        public int? lastPartCount;
    }
}
