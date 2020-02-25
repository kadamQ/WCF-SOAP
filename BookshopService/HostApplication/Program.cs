using HostApplication.BookshopServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HostApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (ServiceHost host = new ServiceHost(typeof(BookshopService.MyBookshopService)))
                {
                    try
                    {
                        host.Open();
                        Console.WriteLine("Host has started @" + DateTime.Now.ToString());
                        Console.ReadLine();
                    }
                    catch (AddressAccessDeniedException ex)
                    {
                        Console.WriteLine("Acces to the address is denied error: " + ex.Message);
                    }
                }
            }
            catch (CommunicationObjectFaultedException er)
            {
                Console.WriteLine("Communication object that has faulted error: " + er.Message);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.ReadKey();
            }
        }
    }
}
