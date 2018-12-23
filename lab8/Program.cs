using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
namespace lab8
{
    class Node
    {
        public string st;
        public int value;
        public Node left;
        public Node right;
    }

    class Tree
    {
        public Node insert(Node root, string st)
        {   int i = 0,f=0,n=st.Length;
            if (root == null)
            {
                root = new Node();
                root.value = 1;
              
                root.st = st;
                return root;
            }

           

            else if (string.Compare(root.st, st) > 0)
            {

                root.left = insert(root.left, st);
            }
            else if (string.Compare(root.st, st) < 0)
            {
                root.right = insert(root.right, st);
            }
            else if (string.Compare(root.st, st) == 0)
            {
                root.value++;
                return root;
            }


                return root;
        }
 public void traverse1(Node root,ref string st,ref int N,int max)
        {
            int f = 0,n;
            if (root == null)
            {
                return ;
            }
            
          
            if ((N<max)&&(N<root.value)&&(root.value<max))
            {
               N= root.value;
                st = "";
                st += root.st;
               
            }
           
            traverse1(root.left,ref st,ref N,max);
            traverse1(root.right,ref st,ref N,max);
           
        }
        public void traverse(Node root)
        {
            if (root == null)
            {
                return;
            }
            
            Console.Write(root.st);
            Console.Write(" ");
            Console.WriteLine(root.value);

            traverse(root.left);
            traverse(root.right);
        }
       
    }

    class BinarySearchTree
    {
        static void Main(string[] args)
        {
            Node root = null;
            Tree bst = new Tree();
            int SIZE = 2000000;string st,st1="";
            char[] a = new char[SIZE];
            int i = 0, n,l=0;
            char s;
            double time; 
            int f=1;
            int[] mas = new int[10];
            string[] mas1 = new string[10];
            for (i = 0; i < 10; i++)
                mas[i] = 0;
            i = 0;
            Stopwatch watch;
            //root = bst.insert(root, "очень");
           
            watch = Stopwatch.StartNew();
            FileStream file = new FileStream("D:\\lab8\\text.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(file, Encoding.Default);
            if (!reader.EndOfStream)
            {
               
                while (!reader.EndOfStream)
                {
                    //if (i == 100)
                    //    break;
                    st = reader.ReadLine();
                    for (int j = 0; j < st.Length - 1; j++)
                    {



                        if ((st[j] == ' ') || (st[j] == '-') || (st[j] == ')') || (st[j] == '(') || (st[j] == '[') || (st[j] == ']') || (st[j] == ',') || (st[j] == '.') || ((st[j] >= '0') && (st[j] <= '9')))

                        {
                            if ((st1 == " ") || (st1 == "-") || (st1 == ")") || (st1 == "(") || (st1 == "[") || (st1 == "]") || (st1 == ",") || (st1 == ".")|| (st1 == ""))
                            {
                                st1 = "";
                                l = 0;
                                continue;
                            }
                            else
                            root = bst.insert(root, st1);
                            
                            l = 0;
                            st1 = "";


                        }
                        else
                        {
                            s = st[j];
                            st1 = st1.Insert(l, Convert.ToString(s));
                            l++;
                        }

                        
                    }
                    
            
                  

                }
                reader.Close();


                watch.Stop();

                time= (double)watch.ElapsedMilliseconds / 1000.0;
                

                watch = Stopwatch.StartNew();

                bst.traverse(root);

                watch.Stop();
                bst.traverse1(root,ref mas1[0],ref mas[0], 200000);
                for(i=1;i<10;i++)
                    bst.traverse1(root, ref mas1[i],ref  mas[i], mas[i-1]);
                time += (double)watch.ElapsedMilliseconds / 1000.0;
                Console.Write("прошло времени ");
                Console.Write( time);
                Console.Write("\n");
                for (i = 0; i < 10; i++)
                {
                    Console.Write(mas1[i]);
                    Console.Write("  ");
                    Console.WriteLine(mas[i]);
                }
                    Console.ReadKey();
            }
        }
    }
}
