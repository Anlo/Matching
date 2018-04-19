using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleMatching;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTests
    {
        Client client1 = new Client("Client1", "1000", "1", "2", "3", "4");
        Client client2 = new Client("Client2", "1000", "4", "3", "2", "1");

        Order order1 = new Order("Client1", "b", "A", "10", "3");
        Order order2 = new Order("Client2", "s", "A", "10", "3");

        [TestMethod]
        public void ParsingClientTest()
        {
            string[] ordersRawData = new string[]
            {
                string.Join("\t", new string[]
                {
                    order1.ClientName,
                    order1.Operation,
                    order1.SecurityPaper,
                    order1.Price.ToString(),
                    order1.Qty.ToString()
                }),
                string.Join("\t", new string[]
                {
                    order2.ClientName,
                    order2.Operation,
                    order2.SecurityPaper,
                    order2.Price.ToString(),
                    order2.Qty.ToString()
                })
            };

            List<Order> orders = Parse.ParseOrder(ordersRawData);

            Assert.AreEqual(orders.Count, 2);

            Assert.AreEqual(orders[0].ClientName, order1.ClientName);
            Assert.AreEqual(orders[0].Operation, order1.Operation);
            Assert.AreEqual(orders[0].SecurityPaper, order1.SecurityPaper);
            Assert.AreEqual(orders[0].Price, order1.Price);
            Assert.AreEqual(orders[0].Qty, order1.Qty);

            Assert.AreEqual(orders[1].ClientName, order2.ClientName);
            Assert.AreEqual(orders[1].Operation, order2.Operation);
            Assert.AreEqual(orders[1].SecurityPaper, order2.SecurityPaper);
            Assert.AreEqual(orders[1].Price, order2.Price);
            Assert.AreEqual(orders[1].Qty, order2.Qty);
        }

        [TestMethod]
        public void ParsingOrderTest()
        {
            string[] clientRawData = new string[]
            {
                string.Join("\t", new string[]
                {
                    client1.Name,
                    client1.Balance.ToString("G"),
                    client1.QtySecurityPaperA.ToString(),
                    client1.QtySecurityPaperB.ToString(),
                    client1.QtySecurityPaperC.ToString(),
                    client1.QtySecurityPaperD.ToString()
                }),
                string.Join("\t", new string[]
                {
                    client2.Name,
                    client2.Balance.ToString("G"),
                    client2.QtySecurityPaperA.ToString(),
                    client2.QtySecurityPaperB.ToString(),
                    client2.QtySecurityPaperC.ToString(),
                    client2.QtySecurityPaperD.ToString()
                })
            };

            List<Client> clients = Parse.ParseClient(clientRawData);

            Assert.AreEqual(clients.Count, 2);

            Assert.AreEqual(clients[0].Name, client1.Name);
            Assert.AreEqual(clients[0].Balance, client1.Balance);
            Assert.AreEqual(clients[0].QtySecurityPaperA, client1.QtySecurityPaperA);
            Assert.AreEqual(clients[0].QtySecurityPaperB, client1.QtySecurityPaperB);
            Assert.AreEqual(clients[0].QtySecurityPaperC, client1.QtySecurityPaperC);
            Assert.AreEqual(clients[0].QtySecurityPaperD, client1.QtySecurityPaperD);

            Assert.AreEqual(clients[1].Name, client2.Name);
            Assert.AreEqual(clients[1].Balance, client2.Balance);
            Assert.AreEqual(clients[1].QtySecurityPaperA, client2.QtySecurityPaperA);
            Assert.AreEqual(clients[1].QtySecurityPaperB, client2.QtySecurityPaperB);
            Assert.AreEqual(clients[1].QtySecurityPaperC, client2.QtySecurityPaperC);
            Assert.AreEqual(clients[1].QtySecurityPaperD, client2.QtySecurityPaperD);
        }

        [TestMethod]
        public void ProcessingTest()
        {
            Client client1Key = new Client("Client1", "970", "4", "2", "3", "4");
            Client client2Key = new Client("Client2", "1030", "1", "3", "2", "1");

            List<Client> clients = new List<Client>()
            {
                client1,
                client2
            };

            List<Order> orders = new List<Order>()
            {
                order1,
                order2
            };

            Processing.Run(ref clients, orders);

            Assert.AreEqual(clients[0].Balance, client1Key.Balance);
            Assert.AreEqual(clients[0].QtySecurityPaperA, client1Key.QtySecurityPaperA);
            Assert.AreEqual(clients[0].QtySecurityPaperB, client1Key.QtySecurityPaperB);
            Assert.AreEqual(clients[0].QtySecurityPaperC, client1Key.QtySecurityPaperC);
            Assert.AreEqual(clients[0].QtySecurityPaperD, client1Key.QtySecurityPaperD);

            Assert.AreEqual(clients[1].Balance, client2Key.Balance);
            Assert.AreEqual(clients[1].QtySecurityPaperA, client2Key.QtySecurityPaperA);
            Assert.AreEqual(clients[1].QtySecurityPaperB, client2Key.QtySecurityPaperB);
            Assert.AreEqual(clients[1].QtySecurityPaperC, client2Key.QtySecurityPaperC);
            Assert.AreEqual(clients[1].QtySecurityPaperD, client2Key.QtySecurityPaperD);
        }
    }
}
