using Delas.Test.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delas.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Service1Client client = new Service1Client("Service1Endpoint"))
            {
                while (true)
                {
                    if (System.Console.ReadLine().Equals("exit"))
                        break;

                    System.Console.WriteLine(client.GetBankName());

                }
            }
        }
    }
}
