using System;
using System.Linq;

namespace shapesay
{
    public class InvRand : Shape
    {
        public InvRand(string message) : base(message)
        {
        }

        string ShoutSplitMessage()
        {
            string buffer = new String(message);

            var numRandomSparkles = buffer.Length / 10;
            var r = new Random();
            for (var idx = 0; idx < numRandomSparkles; idx++)
            {
                var nextSparkleIdx = r.Next(0, buffer.Length);
                var ch = buffer[nextSparkleIdx];
                var replacement = ch switch
                {
                    ' ' => '#',
                    '#' => ' ',
                    _ => ch
                };

                if (ch != '\n')
                {
                    buffer = $"{buffer.Substring(0, nextSparkleIdx)}{replacement}{buffer.Substring(nextSparkleIdx + 1)}";
                }

            }

            return buffer;
        }

        public override string Shout()
        {
            return ShoutSplitMessage();
        }
    }
}