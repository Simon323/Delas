using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Delas.Service
{
    public class Service1 : IService1
    {
        public string GetBankName()
        {
            return "106068 AK-Bank";
        }
    }
}
