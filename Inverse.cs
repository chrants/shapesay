using System;
using System.Linq;

namespace shapesay
{
    public class Inverse : Shape
    {
        public Inverse(string message) : base(message)
        {
        }

        string ShoutSplitMessage()
        {
            string buffer = "";
            for (var idx = 0; idx < message.Length; idx++)
            {
                char ch = message[idx];
                char bufferChar = ch switch
                {
                    ' ' => '#',
                    '#' => ' ',
                    _ => ch
                };

                buffer += bufferChar;
            }

            return buffer;
        }

        public override string Shout()
        {
            return ShoutSplitMessage();
        }
    }
}