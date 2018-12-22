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
        public int kolvo = 1;
        public Node left;
        public Node right;
    }

    class Word
    {
        public string value = "";
        public int kolvo = 0;
    }

    class Tree
    {
        public Tree()
        {
            for(int i = 0; i < arr.Count(); i++)
            {
                arr[i] = new Word();
            }
        }
        public int printI = 0; 
        public Node insert(Node root, string v)
        {
            if (root == null)
            {
                root = new Node();
                root.value = v;
            }
            else if (string.Compare(root.value, v) > 0)
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
        public void traversef(Node root, string word, ref bool flag)
        {
            if (root == null)
            {
                return;
            }
            if(flag == true)
            {
                return;
            }

            if(root.value == word)
            {
                flag = true;
                root.kolvo = root.kolvo + 1;
            }
            if(flag == false)
            {
                traversef(root.left, word, ref flag);

            }
            if (flag == false)
            {
                traversef(root.right, word, ref flag);
            }
        }
        public void printTree(Node root)
        {
            if(root == null)
            {
                return;
            }
            Console.WriteLine(root.value + " -> " + root.kolvo);
            //if (printI % 4 == 3)
            //{
            //    Console.WriteLine();
            //    printI = printI + 1;
            //}
            //printI = printI + 1;
            printTree(root.left);
            printTree(root.right);
        }

        public Word[] arr = new Word[5];
        public void FindBest5(Node root)
        {
            if (root == null)
            {
                return;
            }
            if(root.kolvo > arr[0].kolvo)
            {
                for (int i = (arr.Count() - 1); i > 0; i--)
                {
                    arr[i].kolvo = arr[i - 1].kolvo;
                    arr[i].value = arr[i - 1].value;
                }
                arr[0].kolvo = root.kolvo;
                arr[0].value = root.value;
            }
            else if (root.kolvo > arr[1].kolvo)
            {
                for (int i = (arr.Count() - 1); i > 1; i--)
                {
                    arr[i].kolvo = arr[i - 1].kolvo;
                    arr[i].value = arr[i - 1].value;
                }
                arr[1].kolvo = root.kolvo;
                arr[1].value = root.value;

            }
            else if (root.kolvo > arr[2].kolvo)
            {
                for (int i = (arr.Count() - 1); i > 2; i--)
                {
                    arr[i].kolvo = arr[i - 1].kolvo;
                    arr[i].value = arr[i - 1].value;
                }
                arr[2].kolvo = root.kolvo;
                arr[2].value = root.value;
            }
            else if (root.kolvo > arr[3].kolvo)
            {
                for (int i = (arr.Count() - 1); i > 3; i--)
                {
                    arr[i].kolvo = arr[i - 1].kolvo;
                    arr[i].value = arr[i - 1].value;
                }
                arr[3].kolvo = root.kolvo;
                arr[3].value = root.value;
            }
            else if (root.kolvo > arr[4].kolvo)
            {
                for (int i = (arr.Count() - 1); i > 4; i--)
                {
                    arr[i].kolvo = arr[i - 1].kolvo;
                    arr[i].value = arr[i - 1].value;
                }
                arr[4].kolvo = root.kolvo;
                arr[4].value = root.value;
            }
            FindBest5(root.left);
            FindBest5(root.right);
        }
        public void PrintBest(Node root)
        {
            FindBest5(root);
            for(int i = 0; i < arr.Count(); i++)
            {
                Console.WriteLine(arr[i].value + " " + arr[i].kolvo);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Node root = null;
            char currentpo;
            string ito = "";
            Tree bst = new Tree();
            int SIZE = 2000000;
            int[] a = new int[SIZE];
            bool flag = true;
            bool flag2 = false;
            string u = File.ReadAllText("D:\\Programs\\CSharp\\LabWaP\\LabWaP\\c.txt", System.Text.Encoding.GetEncoding(1251));
            int l = u.Count();
            char current = u[0];

            for (int i = 1; i < l; i++)
            {
                currentpo = u[i];
                if ((current == ' ' || current == '\n' || current == '\r' || current == '(' || current == '"') && currentpo != ' ' && currentpo != '\n' && currentpo != '\r' && currentpo != '(')
                {
                    flag = true;
                }
                if (flag == true && (currentpo == '.' || currentpo == ',' || currentpo == '!' || currentpo == '?' || currentpo == ';' || currentpo == ':' || currentpo == '\n' || currentpo == '\r' || currentpo == ' ' || currentpo == ')' || currentpo == '"' || currentpo == ']'))
                {
                    flag = false;
                    ito = ito + current;
                    bst.traversef(root, ito, ref flag2);
                    if(flag2 == false)
                    {
                        root = bst.insert(root, ito);
                    }
                    flag2 = false;
                    ito = "";
                }

                if (flag == true && current != ' ' && current != '\n' && current != '\r' && current != '(' && current != '"' && (currentpo != '.' || currentpo != ',' || currentpo != '!' || currentpo != '?' || currentpo != ';' || currentpo != ':' || currentpo != '"' || currentpo != ']'))
                {
                    ito = ito + current;
                }
                current = currentpo;
            }
            bst.printTree(root);
            bst.PrintBest(root);
            Console.ReadKey();
        }
    }
}
