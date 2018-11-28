using System.Collections.Generic;
using System.ServiceModel;

namespace Messenger.Library
{
    [ServiceContract]
    public interface IChatService
    {
        [OperationContract]
        List<Message> GetMessages();

        [OperationContract]
        void SendMessage(string text);

        [OperationContract]
        void SaveMessages();

        [OperationContract]
        void LoadMessages();

        [OperationContract]
        void Clear ();
    }
}