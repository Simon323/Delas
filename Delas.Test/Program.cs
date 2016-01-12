using Delas.Model.Repository;
using Delas.Model.Repository.Interfaces;
using Delas.Test.BankServiceReference;
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
            using (BankServiceClient client = new BankServiceClient("BankServiceEndpoint"))
            {
                while (true)
                {
                    if (System.Console.ReadLine().Equals("exit"))
                        break;

                    //System.Console.WriteLine(client.GetBankName());
                    UserSOAP xxx = client.GetUserByLogin("qwer");
                    System.Console.WriteLine(xxx);
                }

                //var result = client.GetUserByLogin("qwer");
                //Console.ReadLine();

            }
        }
    }
}
