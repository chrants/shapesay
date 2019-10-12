using System;

namespace shapesay
{
    public abstract class Shape
    {

        public static readonly int CONSOLE_WIDTH = 50;

        protected string message;

        public Shape(string message) => this.message = message;

        public abstract string Shout();
    }
}