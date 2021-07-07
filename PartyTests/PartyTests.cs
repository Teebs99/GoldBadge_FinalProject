using BBQBooth;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace PartyTests
{
    [TestClass]
    public class PartyTests
    {
        PartyRepo _parties;
        [TestInitialize]
        public void SeedData()
        {
            _parties = new PartyRepo();
            _parties.AddParty(1);
        }
        [TestMethod]
        public void AddParty_ShouldReturnTrue()
        {
            Assert.IsTrue(_parties.AddParty(2));
        }
        [TestMethod]
        public void CollectTicket_ShouldReturnTrue()
        {
            
            Ticket ticket = new Ticket(TicketType.Burger, 2.22, 1.11);
            Assert.IsTrue(_parties.CollectTicket(1, ticket));
        }
        [TestMethod]
        public void GetParty_ShouldReturnSimilarDictionary()
        {
            Dictionary<int, List<Ticket>> newDict = _parties.GetParty();
            Assert.AreEqual(newDict[1], _parties.GetParty()[1]);
        }
        [TestMethod]
        public void GetPartyCost_ShouldEqualTicketCostTotal()
        {
            Ticket ticket = new Ticket(TicketType.Burger, 2.22, 1.11);
            _parties.CollectTicket(1, ticket);
            Assert.AreEqual(3.33, _parties.GetPartyCost(1));

        }
        [TestMethod]
        public void GetTicketCount_ShouldReturnNumOfTickets()
        {
            Ticket ticket = new Ticket(TicketType.Burger, 2.22, 1.11);
            _parties.CollectTicket(1, ticket);
            Assert.AreEqual(1, _parties.GetTicketCount(1, TicketType.Burger));

        }
        [TestMethod]
        public void UpdateCost_GetCostShouldReturnNewTotal()
        {
            Ticket ticket = new Ticket(TicketType.Burger, 2.22, 1.11);
            _parties.CollectTicket(1, ticket);
            _parties.UpdateCost(1, TicketType.Burger, 3.50, 2.01);
            Assert.AreEqual(5.51, _parties.GetPartyCost(1));

        }
        [TestMethod]
        public void DeleteTicket_ShouldHaveEmptyListInDictionary()
        {
            Ticket ticket = new Ticket(TicketType.Burger, 2.22, 1.11);
            _parties.CollectTicket(1, ticket);
            _parties.DeleteTicket(1);
            Assert.AreEqual(0, _parties.GetParty()[1].Count);

        }
    }
}
