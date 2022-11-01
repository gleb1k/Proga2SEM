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
        public BinaryTreeNode<T> SmallLeftTurn(BinaryTreeNode<T> r)
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
            if (r.RightChild != null)
            r.RightChild.Parent = r;

            newRoot.LeftChild = r;
            newRoot.Parent = tempPar;
            return newRoot;
        }
        /// <summary>
        /// Малый правый поворот
        /// </summary>
        /// <param name="r"></param>
        public BinaryTreeNode<T> SmallRightTurn(BinaryTreeNode<T> r)
        {
            BinaryTreeNode<T> tempPar = null;
            if (root.Parent != null)
            {
                tempPar = root.Parent;
            }
            if (r.LeftChild == null)
                throw new Exception("Малый левый поворот невозможен");
            var newRoot = r.LeftChild;

            r.LeftChild = r.LeftChild.RightChild;
            if (r.LeftChild != null)
            r.LeftChild.Parent = r;

            newRoot.RightChild = r;
            newRoot.Parent = tempPar;
            return newRoot;
        }
        /// <summary>
        /// Большой правый поворот
        /// </summary>
        /// <param name="r"></param>
        public BinaryTreeNode<T> BigRightTurn (BinaryTreeNode<T> r)
        {
            BinaryTreeNode<T> tempPar = null;
            if (root.Parent != null)
            {
                tempPar = root.Parent;
            }

            if (r.LeftChild == null || r.LeftChild.RightChild == null)
                throw new Exception("Большой правый поворот невозможен");

            var newRoot = r.LeftChild.RightChild;
            
            r.LeftChild.RightChild = newRoot.LeftChild;
            newRoot.LeftChild.Parent = r.LeftChild;

            newRoot.LeftChild = r.LeftChild;
            r.LeftChild.Parent = newRoot;

            r.LeftChild = newRoot.RightChild;
            if (newRoot.RightChild != null)
                newRoot.RightChild.Parent = r;

            newRoot.RightChild = r;
            r.Parent = newRoot;

            newRoot.Parent = tempPar;

            return newRoot;
        }
        /// <summary>
        /// Большой левый поворот
        /// </summary>
        /// <param name="r"></param>
        public BinaryTreeNode<T> BigLeftTurn(BinaryTreeNode<T> r)
        {
            BinaryTreeNode<T> tempPar = null;
            if (root.Parent != null)
            {
                tempPar = root.Parent;
            }

            if (r.RightChild == null || r.RightChild.LeftChild == null)
                throw new Exception("Большой левый поворот невозможен");

            var newRoot = r.RightChild.LeftChild;

            r.RightChild.LeftChild = newRoot.RightChild;
            newRoot.RightChild.Parent = r.RightChild;

            newRoot.RightChild = r.RightChild;
            r.RightChild.Parent = newRoot;

            r.RightChild = newRoot.LeftChild;
            if (newRoot.LeftChild != null)
                newRoot.LeftChild.Parent = r;

            newRoot.LeftChild = r;
            r.Parent = newRoot;

            newRoot.Parent = tempPar;

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
                //Временный родитель
                var temppar = rootCopy.Parent;
                //Проверка левая или правая вершина. Чтоб потом сделать ссылку для родителя(temppar)
                bool isRightChild =false;
                if (temppar != null && temppar.RightChild == rootCopy)
                {
                    isRightChild = true;
                }
                //Был поворот или нет
                bool isTurned = false;
                //левое вращение
                if (TreeUtils<T>.GetHeight(rootCopy.RightChild) - TreeUtils<T>.GetHeight(rootCopy.LeftChild) >= 2)
                {
                    if (TreeUtils<T>.GetHeight(rootCopy.RightChild.RightChild) - TreeUtils<T>.GetHeight(rootCopy.RightChild.LeftChild) >= 0)
                         rootCopy = SmallLeftTurn(rootCopy);
                    else rootCopy = BigLeftTurn(rootCopy);
                    isTurned = true;
                }
                //правое вращение
                else
                if (TreeUtils<T>.GetHeight(rootCopy.LeftChild) - TreeUtils<T>.GetHeight(rootCopy.RightChild) >= 2)
                {
                    if (TreeUtils<T>.GetHeight(rootCopy.LeftChild.LeftChild) - TreeUtils<T>.GetHeight(rootCopy.LeftChild.RightChild) >= 0)
                        rootCopy = SmallRightTurn(rootCopy);
                    else rootCopy = BigRightTurn( rootCopy);
                    isTurned = true;
                }
                //Если родителя нет, то проверка завершена
                if (temppar == null)
                {
                    root = rootCopy;
                    return;
                }
                else
                {
                    //Меняем родителя
                    rootCopy.Parent = temppar;
                    //Если был поворот то меняем у родителя ссылку на дочерний класс 
                    if (isRightChild && isTurned )
                        temppar.RightChild = rootCopy;
                    else if(isTurned)
                        temppar.LeftChild = rootCopy;
                    //Поднимаемся по родителю
                    rootCopy = rootCopy.Parent;
                }
            }
            //Присваиваем полученное дерево к начальному корню
            root = rootCopy;
        }
        
    }
}
