using System;
using System.Linq;

namespace shapesay
{
    public class Rect : Shape
    {
        public Rect(string message) : base(message)
        {
        }

        string ShoutSplitMessage()
        {
            var messageClone = new String(message);

            var messageLineLength = CONSOLE_WIDTH - 4;
            var height = message.Length / messageLineLength;
            var edge = new String('#', CONSOLE_WIDTH) + '\n';

            var midLine = "# " + new String(' ', messageLineLength) + " #\n";
            var middle = "";
            for (var idx = 0; idx <= height; idx++)
            {
                var currentLineLength = Math.Min(messageClone.Length, messageLineLength);
                var lineMessage = messageClone.Substring(0, currentLineLength);
                messageClone = messageClone.Substring(currentLineLength);
                var line = "# " + lineMessage + new String(' ', messageLineLength - currentLineLength) + " #\n";
                middle += line;
            }

            return edge + midLine + middle + midLine + edge;
        }

        string ShoutPreserveLine(int maxWidth, string line)
        {
            return $"# {line}{new String(' ', maxWidth - line.Length)} #\n";
        }

        string ShoutPreserveMessage()
        {
            var messageLines = message.Split('\n');
            var maxLength = messageLines.Select(line => line.Length).Max();
            var middle = messageLines.Where(line => line.Length > 0)
                                    .Select(line => ShoutPreserveLine(maxLength, line))
                                    .Aggregate((a, b) => a + b);

            var edge = new String('#', maxLength + 4) + '\n';
            var midLine = "# " + new String(' ', maxLength) + " #\n";
            return edge + midLine + middle + midLine + edge;
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