using System;
using System.Linq;

namespace shapesay
{
    public class Append
    {
        private Append()
        {
        }

        public static string AppendMessage(string left, string right)
        {
            var linesLeft = left.Split('\n');
            var linesRight = right.Split('\n');

            var maxNumLines = Math.Max(linesLeft.Length, linesRight.Length);

            static string sanitizeIdx(string[] strs, int idx)
            {
                if (idx < strs.Length)
                {
                    return strs[idx];
                }
                return "";
            };

            var buffer = "";
            for (var i = 0; i < maxNumLines; i++)
            {
                var l = sanitizeIdx(linesLeft, i);
                var r = sanitizeIdx(linesRight, i);
                buffer += l + r + "\n";
            }

            return buffer;
        }
    }
}