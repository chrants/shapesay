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
            var bottom = new String('#', maxWidth) + '\n';

            var middle = "";
            for (var idx = 1; idx <= numLines; idx++)
            {
                var currentLineCharsLength = 2 * idx - 1;
                var currentLineLength = Math.Min(messageClone.Length, currentLineCharsLength);
                var lineMessage = messageClone.Substring(0, currentLineLength);
                messageClone = messageClone.Substring(currentLineLength);
                var line = new String(' ', maxWidth / 2 - idx - 1) + "# "
                         + lineMessage
                         + new String(' ', currentLineCharsLength - currentLineLength) + " #\n";
                middle += line;
            }

            return top + middle + bottom;
        }

        string ShoutPreserveLine(int maxWidth, string line)
        {
            return $"{line}{new String(' ', maxWidth - line.Length)}";
        }

        string ShoutPreserveMessage()
        {
            var messageLines = message.Split('\n');
            var widthAndHeight = Math.Max(messageLines.Select(line => line.Length).Max(), messageLines.Length);
            var middleBase = messageLines.Where(line => line.Length > 0)
                                    .Select((line, idx) => ShoutPreserveLine(widthAndHeight, line))
                                    .ToArray();

            var triangleTopHeight = widthAndHeight / 2 + 1;
            var triangleBaseWidth = 3 * widthAndHeight + 2;

            var offset = widthAndHeight % 2 == 1 ? 0 : 1;

            var tip = new String(' ', triangleBaseWidth / 2) + "#\n";
            var triangleTop = "";
            for (var idx = 1; idx < triangleTopHeight; idx++)
            {
                var currentInsideWidth = 2 * idx - 1;
                var padding = new String(' ', triangleBaseWidth / 2 - idx);
                var insideLine = "#" + new String(' ', currentInsideWidth) + "#";
                var line = padding + insideLine + padding + '\n';
                triangleTop += line;
            }

            var triangleMiddle = "";
            for (var idx = 0; idx < widthAndHeight; idx++)
            {
                var paddingOutside = new String(' ', widthAndHeight - idx);
                var paddingInside = new String(' ', idx);

                string insideLine;
                if (idx < middleBase.Length)
                {
                    insideLine = middleBase[idx];
                }
                else
                {
                    insideLine = ShoutPreserveLine(widthAndHeight, "");
                }

                var line = paddingOutside + "#"
                         + paddingInside
                         + insideLine + new String(' ', offset)
                         + paddingInside + "#\n";
                triangleMiddle += line;
            }

            var bottom = new String('#', triangleBaseWidth + offset) + '\n';

            return tip + triangleTop + triangleMiddle + bottom;
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