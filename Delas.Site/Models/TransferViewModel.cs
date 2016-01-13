using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Delas.Site.Models
{
    public class TransferViewModel
    {
        public int IdAccount { get; set; }

        [Required]
        public string Destiny { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        public double Amount { get; set; }

        [Required]
        public string Title { get; set; }

        public TransferViewModel(int IdAccount, string Destiny, double Amount, string Title)
        {
            this.IdAccount = IdAccount;
            this.Destiny = Destiny;
            this.Amount = Amount;
            this.Title = Title;
        }

        public TransferViewModel() { }

    }

    public class AccountNumber
    {
        public bool IsCorrect { get; set; }
        public bool IsInternal { get; set; }

        public AccountNumber(bool IsCorrect, bool IsInternal)
        {
            this.IsCorrect = IsCorrect;
            this.IsInternal = IsInternal;
        }
    }
}