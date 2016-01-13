using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Delas.Site.Models
{
    public class TransferREST
    {
        public string source { get; set; }
        public string destination { get; set; }
        public string title { get; set; }
        public int amount { get; set; }

        public TransferREST(string source, string destination, string title, int amount)
        {
            this.source = source;
            this.destination = destination;
            this.title = title;
            this.amount = amount;
        }
    }
}