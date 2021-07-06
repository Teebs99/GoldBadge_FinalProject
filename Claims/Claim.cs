using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims
{
    public enum ClaimType { Car, Home, Theft };
    public class Claim
    {
        public int ClaimId { get; set; }
        public ClaimType ClaimType { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; }

        public Claim(int id, ClaimType type, string desc, double amount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimId = id;
            ClaimType = type;
            Description = desc;
            ClaimAmount = amount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            TimeSpan span = DateOfClaim.Date - DateOfIncident.Date;
            if (span.TotalDays > 30) { IsValid = false; }
            else { IsValid = true; }

        }
    }
}
