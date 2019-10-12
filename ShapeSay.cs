using System;

namespace shapesay
{
    class ShapeSay
    {

        static Shape ArgsToShape(string shapeName, string message) =>
            shapeName switch
            {
                "Rect" => new Rect(message),
                _ => new Shapeless(message)
            };


        public static void Say(string[] args)
        {
            string message = args[0];
            for (var idx = 1; idx < args.Length; idx++)
            {
                var arg = args[idx];
                if (arg.StartsWith('-'))
                {
                    message = ArgsToShape(arg.Substring(1), message).Shout();
                }
            }
            Console.Write(message);
        }
    }
}