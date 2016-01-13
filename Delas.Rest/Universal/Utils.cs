using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Delas.Rest.Universal
{
    public class Utils
    {
        public static string num = "106039";

        public static string GenerateNewAccountNumber()
        {
            Random random = new Random();
            string result = "00" + Utils.num;
            for(int i = 0; i < 16; i++)
            {
                result += random.Next(10).ToString();
            }

            string nrb = Utils.CalculateNRB(result);
            result = nrb + result;

            return result;
        }

        public static string CalculateNRB(string accountNumber)
        {
            if (string.IsNullOrEmpty(accountNumber))
                throw new ArgumentException("Nie podano numeru rachunku.");
            accountNumber = accountNumber.Replace(" ", null);
            if (!Regex.IsMatch(accountNumber, @"^\d{24}$"))
                throw new ArgumentException("Podany numer rachunku jest nieprawidłowy.");

            string nr2 = accountNumber + "252100";
            int modulo = 0;
            foreach (char znak in nr2)
                modulo = (10 * modulo + int.Parse(znak.ToString())) % 97;
            modulo = 98 - modulo;

            return string.Format("{0:00}", modulo);
        }
    }
}