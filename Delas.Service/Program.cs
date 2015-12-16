using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Delas.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost serviceHost = new ServiceHost(typeof(Service1)))
            {
                serviceHost.Open();
                Console.WriteLine("Service is open...");

                //

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
