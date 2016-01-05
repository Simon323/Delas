using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Delas.Rest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RESTService" in both code and config file together.
    public class RESTService : IRESTService
    {
        public List<Person> GetPersonsList()
        {
            return Persons.Instance.PersonList;
        }
    }
}
