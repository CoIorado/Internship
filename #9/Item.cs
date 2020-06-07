using System;

namespace Intership
{
    public class Item
    {
        public int Data { get; set; }

        public Item Next { get; set; }

        public Item(int data)
        {
            Data = data;
            Next = null;
        }

        public Item()
        {
            Data = default;
            Next = null;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
