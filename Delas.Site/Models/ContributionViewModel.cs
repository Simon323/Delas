﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Delas.Site.Models
{
    public class ContributionViewModel
    {
        public int IdAccount { get; set; }
        public double Amount { get; set; }

        public ContributionViewModel(int IdAccount, double Amount)
        {
            this.IdAccount = IdAccount;
            this.Amount = Amount;
        }
    }
}