using System;
using System.Linq;

namespace shapesay
{
    public class Triangle : Shape
    {
        public Triangle(string message) : base(message)
        {
        }

        string ShoutSplitMessage()
        {
            var messageClone = new String(message);

            var numLines = (int)Math.Ceiling(Math.Sqrt(message.Length));
            var maxWidth = 2 * (numLines + 2) + 1;

            var top = new String(' ', maxWidth / 2) + "#\n"
                    + new String(' ', (maxWidth) / 2 - 1) + "# #\n";
            var middle = "";
            for (var idx = 1; idx <= numLines; idx++)
            {
                var currentLineCharsLength = 2 * idx - 1;
                var currentLineLength = Math.Min(messageClone.Length, currentLineCharsLength);
                var lineMessage = messageClone.Substring(0, currentLineLength);
                messageClone = messageClone.Substring(currentLineLength);
                var lineWithLeftPad = new String(' ', maxWidth / 2 - idx - 1) + "# " + lineMessage;
                var line = lineWithLeftPad + new String(' ', currentLineCharsLength - currentLineLength) + " #\n";
                middle += line;
            }
            var bottom = new String('#', maxWidth) + '\n';

            return top + middle + bottom;
        }

        // string ShoutPreserveLine(int maxWidth, string line)
        // {
        //     return $"# {line}{new String(' ', maxWidth - line.Length)} #\n";
        // }

        string ShoutPreserveMessage()
        {
            return ShoutSplitMessage(); // doesn't preserve lines atm
            // var messageLines = message.Split('\n');
            // var maxLength = messageLines.Select(line => line.Length).Max();
            // var middle = messageLines.Where(line => line.Length > 0)
            //                         .Select((line, idx) => ShoutPreserveLine(maxLength, line))
            //                         .Aggregate((a, b) => a + b);

            // var edge = new String('#', maxLength + 4) + '\n';
            // var midLine = "# " + new String(' ', maxLength) + " #\n";
            // return edge + midLine + middle + midLine + edge;
        }

        public override string Shout()
        {
            if (message.Contains('\n'))
            {
                return ShoutPreserveMessage();
            }
            else
            {
                return ShoutSplitMessage();
            }
        }
    }
}