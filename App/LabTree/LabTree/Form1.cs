using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabTree
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int SIZE = 1000000;
            while (SIZE < 3000000)
            {
                Node root = null;
                Tree bst = new Tree();
                int[] a = new int[SIZE];

                Random random = new Random();
                Stopwatch watch = Stopwatch.StartNew();

                for (int i = 0; i < SIZE; i++)
                {
                    a[i] = random.Next(10000);
                }

                watch.Stop();

                chart1.Series["Series1"].Points.AddXY(SIZE, (double)watch.ElapsedMilliseconds / 1000.0);
                
                watch = Stopwatch.StartNew();

                for (int i = 0; i < SIZE; i++)
                {
                    root = bst.insert(root, a[i]);
                }

                watch.Stop();

                chart2.Series["Series1"].Points.AddXY(SIZE, (double)watch.ElapsedMilliseconds / 1000.0);
                watch = Stopwatch.StartNew();

                bst.traverse(root);

                watch.Stop();

                chart3.Series["Series1"].Points.AddXY(SIZE, (double)watch.ElapsedMilliseconds / 1000.0);

                SIZE = SIZE + 100000;
            }
        }
    }

    class Node
    {
        public int value;
        public Node left;
        public Node right;
    }

    class Tree
    {
        public Node insert(Node root, int v)
        {
            if (root == null)
            {
                root = new Node();
                root.value = v;
            }
            else if (v < root.value)
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
}
