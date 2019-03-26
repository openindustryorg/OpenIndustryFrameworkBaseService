using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Models;

namespace BaseService
{
    public class ClientsConfiguration
    {
        public IEnumerable<Client> ClientElements
        {
            get
            {
                foreach (Client client in this.Clients)
                {
                    if (client != null)
                        yield return client;
                }
            }
        }

        public List<Client> ClientElementsAsList
        {
            get
            {
                return ClientElements.ToList();
            }
        }

        public Client GetClient(string MachineId)
        {
            return this.ClientElements.Where(s => s.MachineId == MachineId).First();
        }


        private ClientSection ClientConfigurationSection
        {
            get
            {
                return (ClientSection)ConfigurationManager.GetSection("Clients");
            }
        }

        private ClientCollection Clients
        {
            get
            {
                return this.ClientConfigurationSection.ClientsElement;
            }
        }

    }
}
