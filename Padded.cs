using System;
using System.Linq;

namespace shapesay
{
    public class Padded : Shape
    {
        public Padded(string message) : base(message)
        {
        }

        string ShoutSplitMessage()
        {
            var lines = message.Split('\n');
            var maxLineLength = lines.Select((line) => line.Length).Max();
            string buffer = "";

            for (var idx = 0; idx < lines.Length; idx++)
            {
                var line = lines[idx];
                buffer += $"{line}{new string(' ', maxLineLength - line.Length)}\n";
            }

            return buffer;
        }

        public override string Shout()
        {
            return ShoutSplitMessage();
        }
    }
}