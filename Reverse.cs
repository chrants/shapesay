using System;
using System.Linq;

namespace shapesay
{
    public class Reverse : Shape
    {
        public Reverse(string message) : base(message)
        {
        }

        string ShoutSplitMessage()
        {
            var lines = message.Split('\n');
            string buffer = "";
            for (var idx = 0; idx < lines.Length; idx++)
            {
                var lineRev = "";
                var line = lines[idx];

                for (var i = line.Length - 1; i >= 0; i--)
                {
                    lineRev += line[i];
                }

                buffer += lineRev + '\n';
            }

            return buffer;
        }

        public override string Shout()
        {
            return ShoutSplitMessage();
        }
    }
}