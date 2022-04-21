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
        public void SmallLeftTurn(ref BinaryTreeNode<T> r)
        {
            BinaryTreeNode<T> tempPar = null;
            if (root.Parent != null)
            {
                tempPar = root.Parent;
            }
            if (r.RightChild == null)
                throw new Exception("Малый левый поворот невозможен");
            var newRoot = r.RightChild;

            r.RightChild = r.RightChild.LeftChild;
            r.RightChild.Parent = r;

            newRoot.LeftChild = r;
            newRoot.Parent = tempPar;
            return newRoot;
        }

        private BinaryTreeNode<T> SmallLeftTurnCore(BinaryTreeNode<T> r)
        {
            if (r.RightChild == null)
                throw new Exception("Малый левый поворот невозможен");
            var newRoot = r.RightChild;
            r.RightChild = r.RightChild.LeftChild;
            newRoot.LeftChild = r;
            return newRoot;
        }
        public void SmallLeftTurn2(ref BinaryTreeNode<T> r)
        {
            r = SmallLeftTurnCore(r);
        }
        /// <summary>
        /// Малый правый поворот
        /// </summary>
        /// <param name="r"></param>
        public void SmallRightTurn(ref BinaryTreeNode<T> r)
        {
            
            if (r.LeftChild == null)
                throw new Exception("Малый левый поворот невозможен");
            var newRoot = r.LeftChild;
            r.LeftChild = r.LeftChild.RightChild;
            newRoot.RightChild = r;
            return newRoot;
        }
        /// <summary>
        /// Большой правый поворот
        /// </summary>
        /// <param name="r"></param>
        public BinaryTreeNode<T> BigRightTurn (BinaryTreeNode<T> r)
        {
            var newRoot = r.LeftChild.RightChild;
            

            r.LeftChild.RightChild = newRoot.LeftChild;
            //newRoot.LeftChild.Parent = r.LeftChild;

            newRoot.LeftChild = r.LeftChild;
            //r.LeftChild.Parent = newRoot;

            r.LeftChild = newRoot.RightChild;
            //if (r.RightChild != null)
            //newRoot.RightChild.Parent = r;

            newRoot.RightChild = r;
            //r.Parent = newRoot;

            return newRoot;
        }
        /// <summary>
        /// Большой левый поворот
        /// </summary>
        /// <param name="r"></param>
        public void BigLeftTurn(ref BinaryTreeNode<T> r)
        {
            var newRoot = r.RightChild.LeftChild;
            r.RightChild.LeftChild = newRoot.RightChild;
            newRoot.RightChild = r.RightChild;
            r.RightChild = newRoot.LeftChild;
            newRoot.LeftChild = r;
            return newRoot;
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
            
            while (rootCopy != null ) //Проходимся до вершины и проверяем на сбалансированность
            {
                var temppar = rootCopy.Parent;
                //левое вращение
                if (TreeUtils<T>.GetHeight(rootCopy.RightChild) - TreeUtils<T>.GetHeight(rootCopy.LeftChild) >= 2)
                {
                    if (TreeUtils<T>.GetHeight(rootCopy.RightChild.RightChild) - TreeUtils<T>.GetHeight(rootCopy.RightChild.LeftChild) >= 0)
                        SmallLeftTurn(ref rootCopy);
                    else BigLeftTurn(ref rootCopy);
                }
                //правое вращение
                else
                if (TreeUtils<T>.GetHeight(rootCopy.LeftChild) - TreeUtils<T>.GetHeight(rootCopy.RightChild) >= 2)
                {
                    if (TreeUtils<T>.GetHeight(rootCopy.LeftChild.LeftChild) - TreeUtils<T>.GetHeight(rootCopy.LeftChild.RightChild) >= 0)
                        SmallRightTurn(ref rootCopy);
                    else BigRightTurn(ref rootCopy);

                }
                if (temppar == null)
                    root = rootCopy;
                //todo else
                rootCopy.Parent = temppar;
                rootCopy = rootCopy.Parent;
            }


        }
    }
}
