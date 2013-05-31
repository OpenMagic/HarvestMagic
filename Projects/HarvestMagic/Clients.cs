using System.Collections.Generic;
using System.Linq;
using HarvestMagic.Core;
using HarvestMagic.JsonModels;

namespace HarvestMagic
{
    public class Clients : BaseHarvestApi
    {
        public Clients(HarvestAccount account)
            : base(account)
        {
        }

        public IEnumerable<Client> GetAll()
        {
            var jsonClients = Deserialize<ClientJsonModel[]>("/clients");

            return from c in jsonClients
                   select c.client;
        }
    }
}
