using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using HarvestMagic.Models;
using HarvestMagic.Tests.TestConfiguration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HarvestMagic.Tests
{
    [TestClass]
    public class ClientsTests : BaseHarvestTests<Clients>
    {
        [TestClass]
        public class GetAll : BaseClientsTests
        {
            [TestMethod]
            public void ShouldBeListOfAllClients()
            {
                // Given
                var account = Config.Instance.HarvestAccount;
                var clients = new Clients(account);

                // When
                var result = clients.GetAll();

                // Then
                result.Count().Should().BeGreaterThan(0);
                ClientsShouldHaveData(result);
            }
        }

        [TestClass]
        public abstract class BaseClientsTests
        {
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
                client.cache_version.Should().NotBe(0);
                client.created_at.Should().NotBe(DateTime.MinValue);
                client.currency.Should().NotBeBlank();
                client.currency_symbol.Should().NotBeBlank();
                // todo: seems impossible to test client.default_invoice_timeframe because it can be null.
                // todo: seems impossible to test client.details because it can be null.
                // todo: seems impossible to test client.highrise_id because it can be null.
                client.id.Should().NotBe(0);
                // todo: seems impossible to test client.last_invoice_kind because it can be null.
                client.name.Should().NotBeBlank();
                client.statement_key.Should().NotBeBlank();
                client.updated_at.Should().NotBe(DateTime.MinValue);
            }
        }
    }
}
