using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.Trees
{
    public static class TreeRunner
    {
        public static void Run()
        {
            BinarySearchTree<string> binSTree = new BinarySearchTree<string>();
            binSTree.Add("A", 10);
            binSTree.Add("B", 9);
            binSTree.Add("C", 8);
            binSTree.Add("D", 3);
            binSTree.Add("E", 13);
            binSTree.Add("F", 11);
            binSTree.Add("G", 74);
            binSTree.Add("X", 69);
            binSTree.Add("Y", 70);
            binSTree.Add("Z", 68);
            binSTree.Add("N", 75);

            bool x = binSTree.Find(4);
            bool y = binSTree.Find(8);
            bool z = binSTree.Find(74);

            bool w = binSTree.IsExternal(74);
            bool w2 = binSTree.IsExternal(75);
            //bool i = binStree.IsExternal(4);

            //binStree.Remove(11);
            //binStree.Remove(75);
            binSTree.Remove(13);

            //------------------

            var n9 = new BinaryTreeNode<int>(1,9)
            {
                LeftChild = new BinaryTreeNode<int>(1,8),
                RightChild = new BinaryTreeNode<int>(1,11)
            };
            var n15 = new BinaryTreeNode<int>(1,15)
            {
                RightChild = new BinaryTreeNode<int>(1,21)
            };
            var n13 = new BinaryTreeNode<int>(1,13)
            {
                LeftChild = n9,
                RightChild = n15
            };
            var n7 = new BinaryTreeNode<int>(1,7)
            {
                LeftChild = new BinaryTreeNode<int>(1,3),
                RightChild = n13
            };
            var avl = new AVLTree<int>(n7);
            avl.SmallLeftTurn(n7);
            //--------------------

            var n23 = new BinaryTreeNode<int>(1, 23)
            {
                LeftChild = new BinaryTreeNode<int>(1, 19),
                RightChild = new BinaryTreeNode<int>(1, 24)
            };
            var n17 = new BinaryTreeNode<int>(1, 17)
            {
                RightChild = n23,
                LeftChild = new BinaryTreeNode<int>(1, 12)
            };
            var n50 = new BinaryTreeNode<int>(1, 50)
            {
                RightChild = new BinaryTreeNode<int>(1, 70),
                LeftChild = n17
            };
            var avl2 = new AVLTree<int>(n50);
            n50 = avl2.BigRightTurn(n50);

            int m = TreeUtils<int>.GetHeight(null);

            AVLTree<int> newAvl = new AVLTree<int>(new BinaryTreeNode<int>(1, 50));
            newAvl.Add(1, 17);
            newAvl.Add(1, 70);
            newAvl.Add(1, 12);
            newAvl.Add(1, 23);
            newAvl.Add(1, 19);
            newAvl.Add(1, 24);
            newAvl.Add(1, 25);
            newAvl.Add(1, 2);
            newAvl.Add(1, 100);
            newAvl.Add(1, 101);
            newAvl.Add(1, 102);
            newAvl.Add(1, 103);


        }
    }
}
 