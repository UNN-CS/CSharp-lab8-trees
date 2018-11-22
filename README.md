# Работа с бинарными деревьями поиска


## Бинарные деревья поиска

В качестве примера приведена реализация бинарного дерева поиска [отсюда](https://gist.github.com/aaronjwood/7e0fc962c5cd898b3181).

```
using System;
using System.Diagnostics;

namespace BinarySearchTree
{
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

    class BinarySearchTree
    {
        static void Main(string[] args)
        {
            Node root = null;
            Tree bst = new Tree();
            int SIZE = 2000000;
            int[] a = new int[SIZE];

            Console.WriteLine("Generating random array with {0} values...", SIZE);

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

            for (int i = 0; i < SIZE; i++)
            {
                root = bst.insert(root, a[i]);
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
```

### Задание 1. 

> Провести исследование скорости поиска данных в бинарном дереве. Подтвердить опровергнуть теоретическое значение `O(log N)`, где `N` - число элементов.

## Задание 2.

> Модифицировать дерево из примера 1 для работы со строками. Произвести чтение текстового файла (романа Л. Толстого "Война и мир") и провести статистический анализ частоты встречаемости слов романа.
