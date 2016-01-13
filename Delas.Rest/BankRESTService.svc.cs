using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Delas.Rest
{
    public class BankRESTService : IBankRESTService
    {
        public string DoWork()
        {
            return "napis";
        }
    }
}
