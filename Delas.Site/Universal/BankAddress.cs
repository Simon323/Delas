using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Delas.Site.Universal
{
    public class BankAddress
    {
        public string AccountNumber { get; set; }
        public string IPAddress { get; set; }

        public BankAddress(string accountNumber, string IPAddress)
        {
            this.AccountNumber = accountNumber;
            this.IPAddress = IPAddress;
        }
    }

    public class ExternalBank
    {
        public static List<BankAddress> FillBankAddressList()
        {
            List<BankAddress> list = new List<BankAddress>();

            return list;
        }
    }
}