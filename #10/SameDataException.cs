using System;

namespace Intership
{
    class SameDataException : Exception
    {
        public SameDataException() { }
        public SameDataException(string message) : base(message) { }
    }
}
