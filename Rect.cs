using System;

namespace shapesay
{
    public class Rect : Shape
    {
        public Rect(string message) : base(message)
        {
        }

        public override string Shout()
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
    }
}