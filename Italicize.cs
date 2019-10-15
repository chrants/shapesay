using System;
using System.Linq;

namespace shapesay
{
    public class Italicize : Shape
    {
        public Italicize(string message) : base(message)
        {
        }

        string ShoutPreserveMessage()
        {
            var messageLines = message.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            var italicized = "";
            for (var idx = 0; idx < messageLines.Length; idx++)
            {
                var padding = new String(' ', messageLines.Length - idx - 1) + "#";

                var line = padding
                         + messageLines[idx]
                         + "#\n";
                italicized += line;
            }

            return italicized;
        }

        public override string Shout()
        {
            return ShoutPreserveMessage();
        }
    }
}