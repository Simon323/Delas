using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Delas.Rest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBankRESTService" in both code and config file together.
    [ServiceContract]
    public interface IBankRESTService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "Persons/")]
        string DoWork();
    }
}
