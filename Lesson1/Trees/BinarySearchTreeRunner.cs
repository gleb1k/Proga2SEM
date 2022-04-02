using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.Trees
{
    public static class BinarySearchTreeRunner
    {
        public static void Run()
        {
            BinarySearchTree<string> tree = new BinarySearchTree<string>();
            tree.Add("A", 10);
            tree.Add("B", 9);
            tree.Add("C", 8);
            tree.Add("D", 3);
            tree.Add("E", 13);
            tree.Add("F", 11);
            tree.Add("G", 74);
            tree.Add("X", 69);
            tree.Add("Y", 70);
            tree.Add("Z", 68);
            tree.Add("N", 75);

            bool x = tree.Find(4);
            bool y = tree.Find(8);
            bool z = tree.Find(74);

            bool w = tree.IsExternal(74);
            bool w2 = tree.IsExternal(75);
            //bool i = tree.IsExternal(4);

            //tree.Remove(11);
            //tree.Remove(75);
            tree.Remove(13);
        }
    }
}
