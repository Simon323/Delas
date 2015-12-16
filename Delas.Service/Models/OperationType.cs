using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Delas.Service.Models
{
    [DataContract]
    public partial class OperationType
    {
        public OperationType()
        {
            this.Histories = new HashSet<History>();
        }

        public OperationType(int id, string name)
        {
            this.Histories = new HashSet<History>();
            this.Id = id;
            this.Name = name;
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public virtual ICollection<History> Histories { get; set; }
    }
}
