using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using HarvestMagic.Tests.TestConfiguration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HarvestMagic.Tests
{
    [TestClass]
    public class ClientsTests : BaseHarvestTests<Clients>
    {
        [TestMethod]
        public void GetAll_ShouldBeListOfAllClients()
        {
            // Given
            var account = Config.Instance.HarvestAccount;

            // When
            var result = account.Clients.GetAll();

            // Then
            result.Count().Should().BeGreaterThan(0);
            ClientsShouldHaveData(result);
        }
        
        [TestMethod]
        public void GetById_ShouldReturnClientWithData()
        {
            // Given
            var account = Config.Instance.HarvestAccount;
            var clients = account.Clients.GetAll();
            var clientId = clients.First().Id;

            // When
            var client = account.Clients.GetById(clientId);

            // Then
            ClientShouldHaveData(client);
        }
        protected void ClientsShouldHaveData(IEnumerable<Client> clients)
        {
            foreach (var client in clients)
            {
                ClientShouldHaveData(client);
            }
        }

        private void ClientShouldHaveData(Client client)
        {
            // todo: seems impossible to test client.active.
            client.CacheVersion.Should().NotBe(0);
            client.CreatedAt.Should().NotBe(DateTime.MinValue);
            client.Currency.Should().NotBeBlank();
            client.CurrencySymbol.Should().NotBeBlank();
            // todo: seems impossible to test client.default_invoice_timeframe because it can be null.
            // todo: seems impossible to test client.details because it can be null.
            // todo: seems impossible to test client.highrise_id because it can be null.
            client.Id.Should().NotBe(0);
            // todo: seems impossible to test client.last_invoice_kind because it can be null.
            client.Name.Should().NotBeBlank();
            client.UpdatedAt.Should().NotBe(DateTime.MinValue);
        }
    }
}
