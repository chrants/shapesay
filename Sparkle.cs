using System;
using System.Linq;

namespace shapesay
{
    public class Sparkle : Shape
    {
        public Sparkle(string message) : base(message)
        {
        }

        string ShoutSplitMessage()
        {
            var lines = message.Split('\n');
            string buffer = "";
            for (var idx = 0; idx < lines.Length; idx++)
            {
                var words = lines[idx].Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (var wrdIdx = 0; wrdIdx < words.Length; wrdIdx++)
                {
                    buffer += new String(' ', words[wrdIdx].Length) + "#";
                }

                buffer += '\n';
            }

            var numRandomSparkles = buffer.Length / 5;
            var r = new Random();
            for (var idx = 0; idx < numRandomSparkles; idx++)
            {
                var nextSparkleIdx = r.Next(0, buffer.Length);
                if (buffer[nextSparkleIdx] != '\n')
                    buffer = $"{buffer.Substring(0, nextSparkleIdx)}#{buffer.Substring(nextSparkleIdx + 1)}";
            }

            return buffer;
        }

        string ShoutPreserveLine(int maxWidth, string line)
        {
            return $" {line}{new String(' ', maxWidth - line.Length)} ";
        }

        string ShoutPreserveMessage()
        {
            var messageLines = message.Split('\n');
            var widthAndHeight = Math.Max(messageLines.Select(line => line.Length).Max(), messageLines.Length);
            var middleBase = messageLines.Where(line => line.Length > 0)
                                    .Select((line, idx) => ShoutPreserveLine(widthAndHeight, line))
                                    .ToArray();

            var bottom = new String('#', widthAndHeight) + '\n';

            var triangleTop = "";
            for (var idx = 1; idx <= widthAndHeight; idx++)
            {
                var currentInsideWidth = 2 * idx - 1;
                var padding = new String(' ', widthAndHeight * 2 - idx);
                var insideLine = "#" + new String(' ', currentInsideWidth) + "#";
                var line = padding + insideLine + padding + '\n';
                triangleTop += line;
            }
            // Console.WriteLine(triangleTop);

            var triangleMiddle = "";
            for (var idx = 1; idx <= widthAndHeight; idx++)
            {
                var currentInsideWidth = 2 * idx - 1;
                var padding = new String(' ', widthAndHeight - idx) + "#";

                string insideLine;
                if (idx < middleBase.Length)
                {
                    insideLine = middleBase[idx - 1];
                }
                else
                {
                    insideLine = ShoutPreserveLine(widthAndHeight, "");
                }

                var line = padding
                         + insideLine
                         + padding + "#\n";
                triangleMiddle += line;
            }

            return triangleTop + triangleMiddle + bottom;
        }

        public override string Shout()
        {
            // if (message.Contains('\n'))
            // {
            //     return ShoutPreserveMessage();
            // }
            // else
            // {
            return ShoutSplitMessage();
            // }
        }
    }
}