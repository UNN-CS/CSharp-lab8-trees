using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Дуб
{
    class Tree
    {
        private string stroka; // хранимая строка
        private int schetchik_povtoreniy;    // счётчик повторений
        private Tree left;    // ссылка на левое поддерево
        private Tree right;   // ссылка на правое поддерево

        public void vstavka(string stroka)
        {
            if (this.stroka == null)
            {
                this.stroka = stroka;
                this.schetchik_povtoreniy = 1;
            }
            else
            {
                if (this.stroka.CompareTo(stroka) == 1) // если больше
                {
                    if (left == null)
                        this.left = new Tree();
                    left.vstavka(stroka);
                }
                else if (this.stroka.CompareTo(stroka) == -1)
                {
                    if (right == null)
                        this.right = new Tree();
                    right.vstavka(stroka);
                }
                else
                    this.schetchik_povtoreniy++;
            }
            // return schetchik_povtoreniy;
        }

        public Tree Search(string stroka)
        {

            if (this.stroka == stroka)
                return this;
            else if (this.stroka.CompareTo(stroka) == 1)
            {
                if (left != null)
                    return this.left.Search(stroka);
                else
                    throw new Exception("Искомого узла в дереве нет"); //генерирование исключения (throw), если искомый узел не будет найден.
            }
            else
            {
                if (right != null)
                    return this.right.Search(stroka);
                else
                    throw new Exception("Искомого узла в дереве нет"); //генерирование исключения (throw), если искомый узел не будет найден.
            }
        }

        public void MostCommons(int max_repeats, List<Tree> result, Tree root)
        {
            if (root != null)
            {
                //if (root.schetchik_povtoreniy >= max_repeats)

                result.Add(root);

                MostCommons(result.Last().schetchik_povtoreniy, result, root.left);
                MostCommons(result.Last().schetchik_povtoreniy, result, root.right);
            }
        }

        public string Print()
        {
            string s = $" \"{stroka}\" встречается {schetchik_povtoreniy} раз";
            ////MessageBox.Show(s);
            return s;
        }


        public List<Tree> GetCommons(int desired_quantity)
        {
            var result = new List<Tree>();
            MostCommons(0, result, this);
            var selected = result.OrderByDescending(cell => cell.schetchik_povtoreniy).Take(desired_quantity);
            return selected.ToList();
        }
    }
}
