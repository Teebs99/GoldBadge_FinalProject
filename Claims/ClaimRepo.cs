using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims
{
    public class ClaimRepo
    {
        protected readonly Queue<Claim> _claims = new Queue<Claim>();

        public ClaimRepo() { }

        public bool AddClaim(Claim claim)
        {
            int count = _claims.Count;
            _claims.Enqueue(claim);
            return count < _claims.Count;
        }
        public Queue<Claim> GetClaims()
        {
            List<Claim> claimsList = _claims.ToList();
            Queue<Claim> newQueue = new Queue<Claim>();
            foreach(Claim claim in claimsList)
            {
                newQueue.Enqueue(claim);
            }
            return newQueue;
        }
        public Claim NextClaim()
        {
            return _claims.Dequeue();
        }
        public bool UpdateClaim(Claim claim)
        {
            _claims.Peek().ClaimType = claim.ClaimType;
            _claims.Peek().ClaimAmount = claim.ClaimAmount;
            _claims.Peek().DateOfClaim = claim.DateOfClaim;
            _claims.Peek().DateOfIncident = claim.DateOfIncident;
            _claims.Peek().Description = claim.Description;
            return false;
        }
    }
}
