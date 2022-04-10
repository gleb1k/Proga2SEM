using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.Trees
{
    public class AVLTree
    {
        private BinaryTreeNode<int> root;
        public AVLTree(BinaryTreeNode<int> _root)
        {
            root = _root;
        }

        /// <summary>
        /// Малый левый поворот
        /// </summary>
        /// <param name="r"></param>
        public void SmallLeftTurn(BinaryTreeNode<int> r)
        {
            if (r.RightChild == null)
                throw new Exception("Малый левый поворот невозможен");
            var newRoot = r.RightChild;
            r.RightChild = r.RightChild.LeftChild;
            newRoot.LeftChild = r;
            r = newRoot;
        }
        /// <summary>
        /// Малый правый поворот
        /// </summary>
        /// <param name="r"></param>
        public void SmallRightTurn(BinaryTreeNode<int> r)
        {
            if (r.LeftChild == null)
                throw new Exception("Малый левый поворот невозможен");
            var newRoot = r.LeftChild;
            r.LeftChild = r.LeftChild.RightChild;
            newRoot.RightChild = r;
            r = newRoot;
        }
        /// <summary>
        /// Большой левый поворот
        /// </summary>
        /// <param name="root"></param>
        public void BigRightTurn (BinaryTreeNode<int> root)
        {
            var newRoot = root.LeftChild.RightChild;
            root.LeftChild.RightChild = newRoot.LeftChild;
            newRoot.LeftChild = root.LeftChild;
            root.LeftChild = newRoot.RightChild;
            newRoot.RightChild = root;
            root = newRoot;
        }

    }
}
