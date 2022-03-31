using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.Trees
{
    public class BinarySearchTree<T>
    {
        private BinaryTreeNode<T> root;
        /// <summary>
        /// Добавление элемента в дерево по ключу
        /// </summary>
        /// <param name="value"></param>
        /// <param name="key"></param>
        public void Add(T value, int key)
        {

            if (root == null)
                root = new BinaryTreeNode<T>(value, key);
            else
            {
                bool isFind = false;
                var rootCopy = root;
                while (isFind == false)
                {
                    if (key == rootCopy.Key)
                    {
                        rootCopy.Value = value;
                        isFind = true;
                    }
                    else if (key < rootCopy.Key)
                    {
                        if (rootCopy.LeftChild == null)
                        {
                            rootCopy.LeftChild = new BinaryTreeNode<T>(value, key, rootCopy);
                            isFind = true;
                        }
                        else
                            rootCopy = rootCopy.LeftChild;
                    }
                    else
                    {
                        if (rootCopy.RightChild == null)
                        {
                            rootCopy.RightChild = new BinaryTreeNode<T>(value, key, rootCopy);
                            isFind = true;
                        }
                        else
                            rootCopy = rootCopy.RightChild;
                    }
                }
            }
        }
        public void BreadthFirstSearch()
        {
            List<BinaryTreeNode<T>> toVist = new List<BinaryTreeNode<T>>();

            toVist.Add(root);
            while (toVist.Any())
            {
                var current = toVist[0];

                if (current.RightChild != null)
                    toVist.Add(current.RightChild);
                if (current.LeftChild != null)
                    toVist.Add(current.LeftChild);
                toVist.RemoveAt(0);
                Console.WriteLine($"Ключ: {current.Key} ");
            }
        }

        public void InfixTraverse()
        {
            InfixTraverse(root);
        }
        private void InfixTraverse(BinaryTreeNode<T> root)
        {
            if (root == null)
                return;

            if (root.LeftChild != null)
                InfixTraverse(root.LeftChild);
            Console.Write(root.Key + "->");
            if (root.RightChild != null)
                InfixTraverse(root.RightChild);

        }
        public void PrefixTraverse()
        {
            PrefixTraverse(root);
        }
        private void PrefixTraverse(BinaryTreeNode<T> root)
        {
            if (root == null)
                return;
            Console.Write(root.Key + "->");
            if (root.LeftChild != null)
                PrefixTraverse(root.LeftChild);
            if (root.RightChild != null)
                PrefixTraverse(root.RightChild);
        }

        public void PostfixTraverse()
        {
            PostfixTraverse(root);
        }
        private void PostfixTraverse(BinaryTreeNode<T> root)
        {
            if (root == null)
                return;
            if (root.LeftChild != null)
                PostfixTraverse(root.LeftChild);
            if (root.RightChild != null)
                PostfixTraverse(root.RightChild);
            Console.Write(root.Key + "->");
        }


    }
}
