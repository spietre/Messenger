using System;
using System.IO;
using System.Runtime.Serialization;

namespace Messenger.Library
{
    //[Serializable]
    [DataContract]
    public class Message// : ISerializable
    {
        [DataMember]
        public DateTime Time { get; set; }

        [DataMember]
        public string Text { get; set; }

        public Message ()
        {
        }

        public Message (string text)
        {
            Time = DateTime.Now;
            Text = text;
        }

        public override string ToString ()
        {
            return string.Format ("{0:yyyy-MM-dd HH:mm:ss} {1}", Time, Text);
        }

        public void Save(StreamWriter writer)
        {
            writer.WriteLine(Time.ToBinary());
            writer.WriteLine(Text);
        }

        //public void GetObjectData(SerializationInfo info, StreamingContext context)
        //{
        //    info.AddValue("text", Text);
        //    info.AddValue("time", Time);
        //}
    }
}