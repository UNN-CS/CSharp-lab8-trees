using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace Lab8
{
    class Node
    {
        public string value;
        public Node left;
        public Node right;
    }

    class Tree
    {
        public Node insert(Node root, string v)
        {
            if (root == null)
            {
                root = new Node();
                root.value = v;
            }
            else if (string.Compare(root.value,v) > 0)
            {
                root.left = insert(root.left, v);
            }
            else
            {
                root.right = insert(root.right, v);
            }

            return root;
        }

        public void traverse(Node root)
        {
            if (root == null)
            {
                return;
            }

            traverse(root.left);
            traverse(root.right);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Node root = null;
            char currentpo;
            string ito ="";
            Tree bst = new Tree();
            int SIZE = 2000000;
            int[] a = new int[SIZE];
            bool flag = true;
            string u = File.ReadAllText("C:\\Users\\Ivan\\Downloads\\c.txt", System.Text.Encoding.GetEncoding(1251));
            int l = u.Count();
            Console.WriteLine("Generating random array with {0} values...", SIZE);
            char current = u[0];
            
            Random random = new Random();
            Stopwatch watch = Stopwatch.StartNew();

            for (int i = 0; i < SIZE; i++)
            {
                a[i] = random.Next(10000);
            }

            watch.Stop();

            Console.WriteLine("Done. Took {0} seconds", (double)watch.ElapsedMilliseconds / 1000.0);
            Console.WriteLine();
            Console.WriteLine("Filling the tree with {0} nodes...", SIZE);
            watch = Stopwatch.StartNew();

            for (int i = 1; i < l; i++)
            {
                currentpo = u[i];
                if (current == ' ' && currentpo != ' ' && currentpo != '\n' && currentpo != '\r' )
                {
                    flag = true;
                }
                if (flag == true && (currentpo == '.' || currentpo == ',' || currentpo == '!' || currentpo == '?' || currentpo == ';' || currentpo == ':' || currentpo == '\n'|| currentpo == '\r' || currentpo == ' '))
                {
                    flag = false;
                    ito = ito + current;
                    root = bst.insert(root, ito);
                    ito = "";
                }

                if (flag == true && current != ' ' && (currentpo != '.' || currentpo != ',' || currentpo != '!' || currentpo != '?' || currentpo != ';' || currentpo != ':'))
                {
                    ito = ito + current;
                }
                current = currentpo;
            }

            watch.Stop();

            Console.WriteLine("Done. Took {0} seconds", (double)watch.ElapsedMilliseconds / 1000.0);
            Console.WriteLine();
            Console.WriteLine("Traversing all {0} nodes in tree...", SIZE);

            watch = Stopwatch.StartNew();

            bst.traverse(root);

            watch.Stop();

            Console.WriteLine("Done. Took {0} seconds", (double)watch.ElapsedMilliseconds / 1000.0);
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
