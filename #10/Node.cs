using System;

namespace Intership
{
    public class Node : IComparable<Node>
    {
        public static int index;

        public int Data { get; private set; }

        public Node Left { get; set; }

        public Node Right { get; set; }

        public int Level { get; set; }

        public Node()
        {
            Data = default;
            Left = null;
            Right = null;
            Level = 1;
        }

        public Node(int data)
        {
            Data = data;
            Left = null;
            Right = null;
            Level = 1;
        }

        public Node(int data, Node left, Node right)
        {
            Data = data;
            Left = left;
            Right = right;
            Level = 1;
        }

        public static Node BalancedTree(int size, int[] data, int lvl)
        {
            if (size == 0)
            {
                return null;
            }

            Node newNode = new Node(data[index++]);
            newNode.Level = ++lvl;

            int nl = size / 2;
            int nr = size - nl - 1;

            newNode.Left = BalancedTree(nl, data, lvl);
            newNode.Right = BalancedTree(nr, data, lvl);

            return newNode;
        }

        public int CompareTo(Node other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            if (this.Data > other.Data) return 1;
            if (this.Data < other.Data) return -1;

            return 0;
        }

        public void AddSorted(Node newNode)
        {
            newNode.Level++;

            if (newNode.CompareTo(this) == 0)
            {
                throw new SameDataException($"В коллекции уже существует элемент с заданным значением ({newNode.Data})");
            }

            if (newNode.CompareTo(this) == -1)
            {
                if (Left == null)
                {
                    Left = newNode;
                }
                else
                {
                    Left.AddSorted(newNode);
                }
            }

            if (newNode.CompareTo(this) == 1)
            {
                if (Right == null)
                {
                    Right = newNode;
                }
                else
                {
                    Right.AddSorted(newNode);
                }
            }
        }

        public void Print()
        {
            if (Right != null)
            {
                Right.Print();
            }

            Console.ForegroundColor = (ConsoleColor)Level;
            for (int i = 0; i < Level - 1; i++)
                Console.Write("\t");
            Console.WriteLine(Data);
            Console.ResetColor();

            if (Left != null)
            {
                Left.Print();
            }
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}