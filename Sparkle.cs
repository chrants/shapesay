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

        public override string Shout()
        {
            return ShoutSplitMessage();
        }
    }
}