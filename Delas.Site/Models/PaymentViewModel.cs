using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Delas.Site.Models
{
    public class PaymentViewModel
    {
        public int IdAccount { get; set; }

        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        public double Amount { get; set; }

        public PaymentViewModel(int IdAccount, double Amount)
        {
            this.IdAccount = IdAccount;
            this.Amount = Amount;
        }

        public PaymentViewModel()
        {

        }
    }
}