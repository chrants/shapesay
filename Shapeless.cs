using System;

namespace shapesay
{
    public class Shapeless : Shape
    {
        public Shapeless(string message) : base(message)
        {
        }

        public override string Shout() => message;
    }
}