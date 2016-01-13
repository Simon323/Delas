using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Delas.Rest.Models
{
    [DataContract]
    public class Transfer
    {
        [DataMember]
        public string source { get; set; }
        [DataMember]
        public string destination { get; set; }
        [DataMember]
        public string title { get; set; }
        [DataMember]
        public int amount { get; set; }

    }
}