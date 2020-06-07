using System;

namespace Intership
{
    class NonNaturalNumberException : ArgumentException
    {
        public NonNaturalNumberException(string message) : base(message) { }
    }
}
