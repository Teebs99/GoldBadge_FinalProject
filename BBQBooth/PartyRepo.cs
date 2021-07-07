using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBQBooth
{
    public class PartyRepo
    {
        protected readonly Dictionary<int, List<Ticket>> _party = new Dictionary<int, List<Ticket>>();

        public bool CollectTicket(int partyId, Ticket ticket)
        {
            int count = _party[partyId].Count;
            _party[partyId].Add(ticket);
            return count < _party[partyId].Count;
        }
        public bool AddParty(int id)
        {
            int count = _party.Count;
            _party.Add(id, new List<Ticket>());
            return count < _party.Count;
        }
        public Dictionary<int,List<Ticket>> GetParty()
        {
            Dictionary<int, List<Ticket>> newDict = new Dictionary<int, List<Ticket>>();
            foreach(KeyValuePair<int,List<Ticket>> keyValuePair in _party)
            {
                newDict.Add(keyValuePair.Key, keyValuePair.Value);
            }
            return newDict;
        }
        public double GetPartyCost(int partyId)
        {
            double cost = 0;
            foreach(Ticket ticket in _party[partyId])
            {
                cost = ticket.MealCost + ticket.MiscCost + cost;
            }
            return cost;
        }
        public int GetTicketCount(int partyId, TicketType type)
        {
            int count = 0;
            foreach(Ticket ticket in _party[partyId])
            {
                if (ticket.MealType == type) count++;
            }
            return count;
        }
        public void UpdateCost(int partyid, TicketType type, double newMealCost, double newMiscCost)
        {
            foreach(Ticket ticket in _party[partyid])
            {
                if(ticket.MealType == type)
                {
                    ticket.MealCost = newMealCost;
                    ticket.MiscCost = newMiscCost;
                }
            }
        }
        public void DeleteTicket(int partyId) //Deletes Last Ticket
        {
            int lastIndex = _party[partyId].Count - 1;
            _party[partyId].RemoveAt(lastIndex);
        }
    }
}
