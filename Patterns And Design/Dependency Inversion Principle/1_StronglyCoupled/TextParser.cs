using System;
using System.Collections.Generic;
using System.Text;

namespace _1_StronglyCoupled
{
    public class TextParser
    {
        IMessageWriter _writer;
        public TextParser(IMessageWriter writer)
        {
            this._writer = writer;
        }
        public void Wtiter(string msg)
        {
            _writer.Write(msg);
        }
    }
}
