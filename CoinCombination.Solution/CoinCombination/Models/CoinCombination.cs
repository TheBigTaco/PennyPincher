using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CoinCombination.Models
{
    public class Coin
    {
        public double Amount{get; set;}
        private List<int> _moneyDenominations = new List<int> {};

        public Coin (double inputAmount)
        {
          Amount = inputAmount;
        }

        public List<int> Gatekeeper(Coin amount)
        {
            string regexCheck = amount.Amount.ToString("F2");
            Regex regex = new Regex(@"[0-9]*\.[0-9]{2}");
            Match match = regex.Match(regexCheck);
            if (match.Success)
            {
                RemoveDollars(amount);
            }
            return _moneyDenominations;
        }

        public void RemoveDollars(Coin amount)
        {
            int dollars = (int)Math.Floor(amount.Amount);
            _moneyDenominations.Add(dollars);
            double coins = amount.Amount - dollars;
            double amountRemovedQuarters = amount.RemoveQuarters(coins);
            double amountRemovedDimes = amount.RemoveDimes(amountRemovedQuarters);
            int amountRemovedNickels = amount.RemoveNickels(amountRemovedDimes);
            _moneyDenominations.Add(amountRemovedNickels);
        }

        public double RemoveQuarters(double coins)
        {
            int quarters = (int)Math.Floor((coins*100)/25);
            _moneyDenominations.Add(quarters);
            double removedQuarters = (coins*100)- (quarters*25);
            return removedQuarters;
        }

        public double RemoveDimes(double coins)
        {
            int dimes = (int)Math.Floor(Math.Round(coins)/10);
            _moneyDenominations.Add(dimes);
            double removedDimes = Math.Round(coins) - (dimes*10);
            return removedDimes;
        }

        public int RemoveNickels(double coins)
        {
            int nickels = (int)coins/5;
            _moneyDenominations.Add(nickels);
            int removedNickels = (int)coins - (nickels*5);
            return removedNickels;
        }

        public void ClearAll()
        {
            _moneyDenominations.Clear();
        }
    }
}
