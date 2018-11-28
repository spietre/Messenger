using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Server
{
    class Program
    {
        static void Main (string[] args)
        {
            ServiceHost selfHost = new ServiceHost(typeof(ChatService));

            try
            {
                selfHost.Open();
                Console.WriteLine("The service is ready. Press <ENTER> to terminate service.");
                Console.ReadLine();

                selfHost.Close();
            }
            catch (CommunicationException e)
            {
                Console.WriteLine("An exception occured: {0}", e.Message);
                selfHost.Abort();
            }

        }
    }
}
