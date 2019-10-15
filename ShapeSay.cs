using System;

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
                "/" => new Shapeless(message.TrimEnd('\n')),
                _ => new Shapeless(message)
            };

        public static void Say(string[] args)
        {
            // format of args is MESSAGE (MESSAGE|-SHAPE)*
            string message = args[0].Replace("\r", "");
            for (var idx = 1; idx < args.Length; idx++)
            {
                var arg = args[idx];
                if (arg.StartsWith('-'))
                {
                    message = ArgsToShape(arg.Substring(1), message).Shout();
                }
                else
                {
                    message += arg;
                }
            }
            Console.Write(message);
        }
    }
}