using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace lab8_pol
{
        class tree
    {
            public string value;
            public int c = 0;
            public tree left;
            public tree right;
        }
        class String_value
        {
            public int step = 0;

            public tree insert(tree root, string v)
            {
                if (root == null)
                {
                    root = new tree();
                    root.value = v;
                }
                if (v.CompareTo(root.value) == 0) root.c++;
                else if (v.CompareTo(root.value) < 0)
                {
                    root.left = insert(root.left, v);
                }
                else
                {
                    root.right = insert(root.right, v);
                }

                return root;
            }
            public void traverse(tree root)
            {
                if (root == null)
                {
                    return;
                }
                Console.WriteLine("{1} - {0} ", root.value, root.c);
                traverse(root.left);
                traverse(root.right);
            }
        }
        class Search
        {
            static void Main(string[] args)
            {
                tree root = null;
                String_value bst = new String_value();
                string[] words;
                string line;
                System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\TopT\Documents\Visual Studio 2017\project\lab8 pol\lab8 pol\TextC.txt");
                while ((line = file.ReadLine()) != null)
                {
                    words = line.Split(' ');
                    foreach (string word in words)
                    {
                        root = bst.insert(root, word.Trim(new Char[] { '/', ',', '.', '"', '-',' ','_','\n','[',']',';',':','!',}));
                    }
                }
                file.Close();
                bst.traverse(root);
            }
        }
    }