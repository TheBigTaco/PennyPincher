using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoinCombination.Models;

namespace CoinCombination.Tests
{
    [TestClass]
    public class CoinCombinationTest : IDisposable
    {
        public void Dispose()
        {
            Coin.ClearAll();
        }
        [TestMethod]
        public void Gatekeeper_ChecksForViability_List()
        {
            List<int> expectedDollars = new List<int> {111,0,1,0,0};
            Coin newCoin = new Coin(111.10);
            CollectionAssert.AreEqual(expectedDollars, newCoin.Gatekeeper(newCoin));
        }
        [TestMethod]
        public void Gatekeeper_RemoveDollarsFromAmountInput_List()
        {
            List<int> expectedDollars = new List<int> {1,0,0,0,0};
            Coin newCoin = new Coin(1.00);
            CollectionAssert.AreEqual(expectedDollars, newCoin.Gatekeeper(newCoin));
        }

        [TestMethod]
        public void Gatekeeper_RemoveQuartersFromAmountInput_List()
        {
            List<int> expectedDollars = new List<int> {1,1,0,0,0};
            Coin newCoin = new Coin(1.25);
            CollectionAssert.AreEqual(expectedDollars, newCoin.Gatekeeper(newCoin));
        }

        [TestMethod]
        public void Gatekeeper_RemoveDimesFromAmountInput_List()
        {
            List<int> expectedDollars = new List<int> {1,1,1,0,0};
            Coin newCoin = new Coin(1.35);
            CollectionAssert.AreEqual(expectedDollars, newCoin.Gatekeeper(newCoin));
        }

        [TestMethod]
        public void Gatekeeper_RemoveNickelsFromAmountInput_List()
        {
            List<int> expectedDollars = new List<int> {1,1,1,1,0};
            Coin newCoin = new Coin(1.40);
            CollectionAssert.AreEqual(expectedDollars, newCoin.Gatekeeper(newCoin));
        }

        [TestMethod]
        public void Gatekeeper_RemovePenniesFromAmountInput_List()
        {
            List<int> expectedDollars = new List<int> {1,1,1,1,1};
            Coin newCoin = new Coin(1.41);
            CollectionAssert.AreEqual(expectedDollars, newCoin.Gatekeeper(newCoin));
        }
    }
}
