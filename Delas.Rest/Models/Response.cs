using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Delas.Rest.Models
{
    [DataContract]
    public class Response
    {
        [DataMember]
        public string message { get; set; }
        [DataMember]
        public List<Errors> errors { get; set; }

        public Response()
        {
            errors = new List<Errors>();
        }
    }

    [DataContract]
    public class Errors
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string description { get; set; }
    }
}