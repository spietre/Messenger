using Messenger.Library;
using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using System.Xml;
using System.Xml.Serialization;
using Message = Messenger.Library.Message;

namespace Messenger.Server
{
    [ServiceBehavior (InstanceContextMode = InstanceContextMode.Single)]
    class ChatService : IChatService
    {
        private readonly List<Message> _messages = new List<Message>();

        public List<Message> GetMessages ()
        {
            return _messages;
        }

        public void SendMessage (string text)
        {
            _messages.Add(new Message(text));
        }

        public void SaveMessages()
        {
            using (StreamWriter writer = File.CreateText("messages.txt"))
            {
                foreach (Message message in _messages)
                {
                    message.Save(writer);
                }
            }
        }

        public void LoadMessages()
        {
            _messages.Clear();
            using (StreamReader reader = new StreamReader("messages.txt"))
            {
                while (!reader.EndOfStream)
                {
                    DateTime time = DateTime.FromBinary(Convert.ToInt64(reader.ReadLine()));
                    string message = reader.ReadLine();

                    Message msg = new Message();
                    msg.Time = time;
                    msg.Text = message;

                    _messages.Add(msg);
                }
            }
        }

        public void Clear ()
        {
            _messages.Clear();
        }
    }
}
