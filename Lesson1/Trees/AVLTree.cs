using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.Trees
{
    public class AVLTree<T>
    {
        private BinaryTreeNode<T> root;
        public AVLTree(BinaryTreeNode<T> _root)
        {
            root = _root;
        }

        /// <summary>
        /// Малый левый поворот
        /// </summary>
        /// <param name="r"></param>
        public void SmallLeftTurn(BinaryTreeNode<T> r)
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
        public void SmallRightTurn(BinaryTreeNode<T> r)
        {
            if (r.LeftChild == null)
                throw new Exception("Малый левый поворот невозможен");
            var newRoot = r.LeftChild;
            r.LeftChild = r.LeftChild.RightChild;
            newRoot.RightChild = r;
            r = newRoot;
        }
        /// <summary>
        /// Большой правый поворот
        /// </summary>
        /// <param name="r"></param>
        public void BigRightTurn (ref BinaryTreeNode<T> r)
        {
            var newRoot = r.LeftChild.RightChild;
            r.LeftChild.RightChild = newRoot.LeftChild;
            newRoot.LeftChild = r.LeftChild;
            r.LeftChild = newRoot.RightChild;
            newRoot.RightChild = r;
            r = newRoot;
        }
        /// <summary>
        /// Большой левый поворот
        /// </summary>
        /// <param name="r"></param>
        public void BigLeftTurn(BinaryTreeNode<T> r)
        {
            var newRoot = r.RightChild.LeftChild;
            r.RightChild.LeftChild = newRoot.RightChild;
            newRoot.RightChild = r.RightChild;
            r.RightChild = newRoot.LeftChild;
            newRoot.LeftChild = r;
            r = newRoot;
        }

        public void Add(T value, int key)
        {
            var rootCopy = root;
            #region добавление узла (как в бинарном дереве)
            if (root == null)
                root = new BinaryTreeNode<T>(value, key);
            else
            {
                bool isFind = false;
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
            #endregion

            while (rootCopy != null) //Проходимся до вершины и проверяем на сбалансированность
            {

                //левое вращение
                if (TreeUtils<T>.GetHeight(rootCopy.RightChild) - TreeUtils<T>.GetHeight(rootCopy.LeftChild) >= 2)
                {
                    if (TreeUtils<T>.GetHeight(rootCopy.RightChild.RightChild) - TreeUtils<T>.GetHeight(rootCopy.RightChild.LeftChild) >= 0)
                        SmallLeftTurn(rootCopy);
                    else BigLeftTurn(rootCopy);
                }
                //правое вращение
                else
                if (TreeUtils<T>.GetHeight(rootCopy.LeftChild) - TreeUtils<T>.GetHeight(rootCopy.RightChild) >= 2)
                {
                    if (TreeUtils<T>.GetHeight(rootCopy.LeftChild.LeftChild) - TreeUtils<T>.GetHeight(rootCopy.LeftChild.RightChild) >= 0)
                        SmallRightTurn(rootCopy);
                    else BigRightTurn(ref rootCopy);

                }

                rootCopy = rootCopy.Parent;
            }


        }
    }
}
