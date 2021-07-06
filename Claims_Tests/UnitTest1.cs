using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Claims;
using System.Collections.Generic;

namespace Claims_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddClaim_ShouldReturnTrue()
        {
            Claim claim = new Claim(1, ClaimType.Car, "Claim 1",400.00d, new DateTime(2018,4,25),new DateTime(2018,4,27));
            ClaimRepo claims = new ClaimRepo();
            Assert.IsTrue(claims.AddClaim(claim));
        }
        [TestMethod]
        public void GetClaims_ShouldReturnQueue()
        {
            Claim claim = new Claim(1, ClaimType.Car, "Claim 1", 400.00d, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27));
            ClaimRepo claims = new ClaimRepo();
            claims.AddClaim(claim);
            Queue<Claim> expected = claims.GetClaims();
            Assert.AreEqual(expected.Peek(), claims.NextClaim());
        }
        [TestMethod]
        public void HandleNextClaim_ShouldNotContainClaim()
        {
            Claim claim = new Claim(1, ClaimType.Car, "Claim 1", 400.00d, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27));
            ClaimRepo claims = new ClaimRepo();
            claims.AddClaim(claim);
            int count = claims.GetClaims().Count;
            claims.NextClaim();
            Assert.IsFalse(claims.GetClaims().Contains(claim));

        }
        [TestMethod]
        public void UpdateClaim_ShouldBeEqual()
        {
            Claim claim = new Claim(1, ClaimType.Car, "Claim 1", 400.00d, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27));
            Claim newClaim = new Claim(1, ClaimType.Home, "Claim 1 Updated", 4000.00d, new DateTime(2018, 4, 26), new DateTime(2018, 4, 27));
            ClaimRepo claims = new ClaimRepo();
            claims.AddClaim(claim);
            claims.UpdateClaim(newClaim);
            Assert.AreEqual(newClaim.Description, claims.GetClaims().Peek().Description);

        }
    }
}
