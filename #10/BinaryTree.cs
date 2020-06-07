using System;
using System.Collections;
using System.Collections.Generic;

namespace Intership
{
    public enum TreeType
    {
        Search,
        Balanced
    }
    public class BinaryTree : IEnumerable<int>
    {
        public Node Root { get; private set; }

        public int Count
        {
            get => Preorder().Count;
        }

        public int MaxLevel
        {
            get
            {
                if (Root == null)
                    return 0;

                List<int> levels = LevelList(Root);
                levels.Sort();
                return levels[levels.Count - 1];
            }
        }

        public TreeType TreeType { get; private set; }

        public BinaryTree(TreeType treeType)
        {
            Initialize(null);
            this.TreeType = treeType;
        }

        public void Add(int data)
        {
            if (Root == null)
            {
                Initialize(new Node(data));
                return;
            }

            if (Contains(data))
            {
                throw new SameDataException($"В коллекции уже существует элемент с заданным значением ({data})");
            }

            Node newNode = new Node(data);
            if (TreeType == TreeType.Balanced)
            {
                List<int> elements = Preorder();
                elements.Add(data);
                int[] dataArray = elements.ToArray();
                Clear();

                Node.index = 0;
                Root = Node.BalancedTree(dataArray.Length, dataArray, 0);
            }
            else
            {
                Root.AddSorted(newNode);
            }
        }

        public int Find(int data)
        {
            List<int> list = Inorder();

            foreach (int num in list)
            {
                if (num == data)
                    return num;
            }

            return default;
        }

        public List<int> FindAll(int data)
        {
            List<int> list = Inorder();
            List<int> result = new List<int>();

            foreach (int num in list)
            {
                if (num == data)
                    result.Add(num);
            }

            return result;
        }

        public bool Contains(int data)
        {
            List<int> list = Inorder();

            foreach (int num in list)
            {
                if (num == data)
                    return true;
            }

            return false;
        }

        public bool Remove(int data)
        {
            if (Root == null)
            {
                return false;
            }

            List<int> elements = Preorder();

            bool isRemoved = elements.Remove(data);
            if (!isRemoved)
            {
                return false;
            }

            Clear();

            if (TreeType == TreeType.Balanced)
            {
                int[] dataArray = elements.ToArray();
                Clear();

                Node.index = 0;
                Root = Node.BalancedTree(dataArray.Length, dataArray, 0);
            }
            else
            {
                foreach (int element in elements)
                {
                    Add(element);
                }
            }

            return true;
        }

        public void IntoSearch()
        {
            if (TreeType == TreeType.Search)
            {
                return;
            }

            TreeType = TreeType.Search;

            List<int> elements = Preorder();
            Clear();

            foreach (int element in elements)
            {
                Add(element);
            }
        }

        public void IntoBalanced()
        {
            if (TreeType == TreeType.Balanced)
            {
                return;
            }

            TreeType = TreeType.Balanced;

            List<int> elements = Preorder();
            int[] dataArray = elements.ToArray();
            Clear();

            Node.index = 0;
            Root = Node.BalancedTree(dataArray.Length, dataArray, 0);
        }

        public void Clear()
        {
            Initialize(null);
        }

        public void Print()
        {
            Console.ResetColor();
            if (Root == null)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(" >> ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("BINARY TREE IS EMPTY");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.DarkGray;
            for (int i = 0; i < MaxLevel; i++)
                Console.Write("-------");
            Console.WriteLine();
            Console.ResetColor();

            Root.Print();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            for (int i = 0; i < MaxLevel; i++)
                Console.Write("-------");
            Console.WriteLine();
            Console.ResetColor();
        }

        public void PrintAdvanced()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("TYPE: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(TreeType.ToString() + "\n");
            Console.ResetColor();
            TreePrinter.Print(Root);
        }

        //Функция для обхода дерева по уровням (в виде выходного параметра передается список, содержащий информацию о кол-ве вершин на каждом уровне)
        public List<int> Levelorder(out List<int> levelList)
        {
            if (Root == null)
            {
                levelList = new List<int>();
                return new List<int>();
            }

            return Levelorder(Root, out levelList);
        }

        private List<int> Levelorder(Node node, out List<int> levelList)
        { 
            List<int> list = new List<int>();
            Queue<Node> queue = new Queue<Node>();

            levelList = new List<int>(MaxLevel);
            for (int i = 0; i < MaxLevel; i++)
            {
                levelList.Add(0);
            }

            do
            {
                if (queue.Count != 0)
                {
                    node = queue.Dequeue();
                }

                if (node.Left != null)
                {
                    queue.Enqueue(node.Left);
                }

                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }

                list.Add(node.Data);
                levelList[node.Level - 1]++;

            } while (queue.Count != 0);

            return list;
        }

        //Префиксный обход дерева:
        //1. Элемент
        //2. Правое
        //3. Левое
        public List<int> Preorder()
        {
            if (Root == null)
            {
                return new List<int>();
            }

            return Preorder(Root);
        }

        private List<int> Preorder(Node node)
        {
            List<int> list = new List<int>();

            if (node != null)
            {
                list.Add(node.Data);

                if (node.Left != null)
                {
                    list.AddRange(Preorder(node.Left));
                }

                if (node.Right != null)
                {
                    list.AddRange(Preorder(node.Right));
                }
            }

            return list;
        }

        //Постфиксный обход дерева:
        //1. Левое
        //2. Правое
        //3. Элемент
        public List<int> Postorder()
        {
            if (Root == null)
            {
                return new List<int>();
            }

            return Postorder(Root);
        }

        private List<int> Postorder(Node node)
        {
            List<int> list = new List<int>();

            if (node != null)
            {
                if (node.Left != null)
                {
                    list.AddRange(Postorder(node.Left));
                }

                if (node.Right != null)
                {
                    list.AddRange(Postorder(node.Right));
                }

                list.Add(node.Data);
            }

            return list;
        }

        //Инфиксный обход дерева:
        //1. Левое
        //2. Элемент
        //3. Правое
        public List<int> Inorder()
        {
            if (Root == null)
            {
                return new List<int>();
            }

            return Inorder(Root);
        }

        private List<int> Inorder(Node node)
        {
            List<int> list = new List<int>();

            if (node != null)
            {
                if (node.Left != null)
                {
                    list.AddRange(Inorder(node.Left));
                }

                list.Add(node.Data);

                if (node.Right != null)
                {
                    list.AddRange(Inorder(node.Right));
                }
            }

            return list;
        }

        private List<int> LevelList(Node node)
        {
            if (node == null)
                return null;

            List<int> levels = new List<int>();

            if (node != null)
            {
                levels.Add(node.Level);

                if (node.Left != null)
                {
                    levels.AddRange(LevelList(node.Left));
                }

                if (node.Right != null)
                {
                    levels.AddRange(LevelList(node.Right));
                }
            }

            levels.Sort();
            return levels;
        }

        private void Initialize(Node node)
        {
            Root = node;
        }

        public IEnumerator<int> GetEnumerator()
        {
            List<int> list = Inorder();

            foreach (int data in list)
            {
                yield return data;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class TreePrinter
    {
        public static void Print(Node root)
        {
            List<List<string>> lines = new List<List<string>>();

            List<Node> level = new List<Node>();
            List<Node> next = new List<Node>();

            level.Add(root);
            int nn = 1;

            int widest = 0;

            while (nn != 0)
            {
                List<string> line = new List<string>();

                nn = 0;

                foreach (Node n in level)
                {
                    if (n == null)
                    {
                        line.Add(null);

                        next.Add(null);
                        next.Add(null);
                    }
                    else
                    {
                        string aa = n.Data.ToString();
                        line.Add(aa);
                        if (aa.Length > widest) widest = aa.Length;

                        next.Add(n.Left);
                        next.Add(n.Right);

                        if (n.Left != null) nn++;
                        if (n.Right != null) nn++;
                    }
                }

                if (widest % 2 == 1) widest++;

                lines.Add(line);

                List<Node> tmp = level;
                level = next;
                next = tmp;
                next.Clear();
            }

            int perpiece = lines[lines.Count - 1].Count * (widest + 4);
            for (int i = 0; i < lines.Count; i++)
            {
                List<String> line = lines[i];
                int hpw = (int)Math.Floor(perpiece / 2f) - 1;

                if (i > 0)
                {
                    for (int j = 0; j < line.Count; j++)
                    {
                        // split node
                        char c = ' ';
                        if (j % 2 == 1)
                        {
                            if (line[j - 1] != null)
                            {
                                c = (line[j] != null) ? '┴' : '┘';
                            }
                            else
                            {
                                if (j < line.Count && line[j] != null) c = '└';
                            }
                        }
                        Console.Write(c);

                        // lines and spaces
                        if (line[j] == null)
                        {
                            for (int k = 0; k < perpiece - 1; k++)
                            {
                                Console.Write(" ");
                            }
                        }
                        else
                        {
                            for (int k = 0; k < hpw; k++)
                            {
                                Console.Write(j % 2 == 0 ? " " : "─");
                            }
                            Console.Write(j % 2 == 0 ? "┌" : "┐");
                            for (int k = 0; k < hpw; k++)
                            {
                                Console.Write(j % 2 == 0 ? "─" : " ");
                            }
                        }
                    }
                    Console.WriteLine();
                }

                // print line of numbers
                for (int j = 0; j < line.Count; j++)
                {

                    String f = line[j];
                    if (f == null) f = "";
                    int gap1 = (int)Math.Ceiling(perpiece / 2f - f.Length / 2f);
                    int gap2 = (int)Math.Floor(perpiece / 2f - f.Length / 2f);

                    // a number
                    for (int k = 0; k < gap1; k++)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(f);
                    for (int k = 0; k < gap2; k++)
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();

                perpiece /= 2;
            }
        }
    }
}