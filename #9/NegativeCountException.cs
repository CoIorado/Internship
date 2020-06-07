using System;

namespace Intership
{
    class NegativeCountException : ArgumentException
    {
        public NegativeCountException(string message) : base(message) { }
    }
}
