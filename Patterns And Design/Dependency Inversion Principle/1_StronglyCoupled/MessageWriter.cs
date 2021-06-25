using System;
using System.Collections.Generic;
using System.Text;

namespace _1_StronglyCoupled
{
    public class MessageWriter : IMessageWriter
    {
        public void Write(string message)
        {
            Console.WriteLine($"MessageWriter.Write(message: \"{message}\")");
        }
    }
    public interface IMessageWriter
    {
        void Write(string message);
    }
}
