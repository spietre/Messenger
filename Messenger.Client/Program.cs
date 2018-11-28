using System;
using System.ServiceModel;
using Messenger.Library;

namespace Messenger.Client
{
    class Program
    {
        static void Main (string[] args)
        {
            using (var channelFactory = new ChannelFactory<IChatService>("myTcpBinding"))
            {
                IChatService client = channelFactory.CreateChannel();

                while (true)
                {
                    Console.Clear();
                    foreach (Message message in client.GetMessages())
                    {
                        Console.WriteLine(message);
                    }

                    Console.WriteLine("Zadajte novu spravu");
                    string text = Console.ReadLine();

                    if (text == "save")
                    {
                        client.SaveMessages();
                    }
                    else if (!string.IsNullOrWhiteSpace(text))
                    {
                        client.SendMessage(text);
                    }

                }
            }

        }
    }
}
