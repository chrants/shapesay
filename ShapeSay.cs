using System;
using System.Collections.Generic;

namespace shapesay
{
    class ShapeSay
    {

        static Shape ArgsToShape(string shapeName, string message) =>
            shapeName switch
            {
                "Rect" => new Rect(message),
                "Tri" => new Triangle(message),
                "Sparkle" => new Sparkle(message),
                "Inv" => new Inverse(message),
                "InvRand" => new InvRand(message),
                "Ital" => new Italicize(message),
                "Pad" => new Padded(message),
                "Reverse" => new Reverse(message),
                "/" => new Shapeless(message.TrimEnd('\n')),
                _ => new Shapeless(message)
            };

        static string ParseArgs(string[] args)
        {
            static List<string> AccumulateNextExpression(string[] restArgs, ref int argIdx)
            {
                var tmpAccumulatedExpression = new List<string>();
                var idx = argIdx;

                var stackDepth = 0;
                for (; idx < restArgs.Length; idx++) // consume arguments
                {
                    tmpAccumulatedExpression.Add(restArgs[idx]);

                    if (restArgs[idx].Equals("("))
                    {
                        stackDepth++;
                    };
                    if (restArgs[idx].Equals(")"))
                    {
                        stackDepth--;
                    };
                    if (stackDepth == 0)
                    {
                        break;
                    }
                }

                argIdx = idx;
                return tmpAccumulatedExpression;
            }

            // format of args is MESSAGE (MESSAGE|-SHAPE)*
            string message = args[0].Replace("\r", "");
            for (var idx = 1; idx < args.Length; idx++)
            {
                var arg = args[idx];
                if (arg.StartsWith("-"))
                {
                    message = ArgsToShape(arg.Substring(1), message).Shout();
                }
                else if (arg.Equals("("))
                {
                    List<string> nextExpression = AccumulateNextExpression(args, ref idx);
                    nextExpression.RemoveAt(0); // This paren
                    message += ParseArgs(nextExpression.ToArray());
                }
                else if (arg.Equals(")")) { }
                else if (arg.Equals("+"))
                {
                    idx++;
                    string[] nextExpression = AccumulateNextExpression(args, ref idx).ToArray();
                    var rightMessage = ParseArgs(nextExpression);
                    message = Append.AppendMessage(message, rightMessage);
                    // idx++; // Consume next argument as well
                }
                else
                {
                    message += arg;
                }
            }

            return message;
        }

        public static void Say(string[] args)
        {
            // string[] fakeArgs = { "text", "-Rect", "+", "hello", "(", "something", "-Rect", ")" };
            string message = ParseArgs(args);
            Console.Write(message);
        }
    }
}