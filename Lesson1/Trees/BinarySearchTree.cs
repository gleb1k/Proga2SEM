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
        /// <summary>
        /// обойти всё дерево, следуя порядку (левое поддерево, вершина, правое поддерево). Элементы по возрастанию
        /// </summary>
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
        /// <summary>
        /// обойти всё дерево, следуя порядку (вершина, левое поддерево, правое поддерево). Элементы, как в дереве
        /// </summary>
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
        /// <summary>
        /// обойти всё дерево, следуя порядку (левое поддерево, правое поддерево, вершина). Элементы в обратном порядке, как в дереве
        /// </summary>
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
        /// <summary>
        /// возвращает значение корня дерева
        /// </summary>
        public T Root()
        {
            return root.Value;
        }

        /// <summary>
        /// возвращает значение «родителя» для вершины в позиции p
        /// </summary>
        public T Parent(int p)
        {
            throw new Exception();
        }

        /// <summary>
        /// возвращает значение «самого левого сына» для вершины в позиции p.
        /// изначально надо было вернуть позицию
        /// </summary>
        public T LeftMostChild(int p)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// возвращает значение «правого брата» для вершины в позиции p.
        /// изначально надо было вернуть позицию
        /// </summary>
        public T RightSibling(int p)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// возвращает элемент дерева (хранимую информацию) для вершины в позиции p.
        /// </summary>
        public T Element(int p)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// проверяет, является ли p позицией внутренней вершины (не листа)
        /// </summary>
        public bool IsInternal(int p)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// проверяет, является ли p позицией листа дерева.
        /// </summary>
        public bool IsExternal(int p)
        {
            if (root == null)
            {
                throw new ArgumentOutOfRangeException("Дерево пусто");
            }
            var rootCopy = root;
            bool isFind = false;
            while (isFind == false)
            {
                if (rootCopy.Key == p)
                {
                    if ((rootCopy.LeftChild == null) && (rootCopy.RightChild == null))
                        return true;
                    else return false;
                }
                if (p < rootCopy.Key)
                {
                    if (rootCopy.LeftChild == null)
                    {
                        throw new ArgumentOutOfRangeException("Позиции не существует!");
                    }
                    rootCopy = rootCopy.LeftChild;
                }
                else if (p > rootCopy.Key)
                {
                    if (rootCopy.RightChild == null)
                    {
                        throw new ArgumentOutOfRangeException("Позиции не существует!");
                    }
                    rootCopy = rootCopy.RightChild;
                }
            }
            return false;
        }

        /// <summary>
        /// проверяет, является ли p позицией корня.
        /// </summary>
        public bool IsRoot(int p)
        {
            throw new Exception();
        }

        /// <summary>
        /// проверяет, является ли key ключом корневого узла.
        /// </summary>
        public bool IsRootByKey(int key)
        {
            throw new Exception();
        }

        /// <summary>
        /// Поиск элемента в дереве
        /// </summary>
        public bool Find(int key)
        {
            if (root == null)
            {
                throw new ArgumentOutOfRangeException("Дерево пусто");
            }
            var rootCopy = root;
            bool isFind = false;
            while (isFind==false)
            {
                if (rootCopy.Key == key)
                {
                    return true;
                    
                }
                 
                if (key < rootCopy.Key)
                {
                    if (rootCopy.LeftChild == null)
                    {
                        return false;
                    }
                    rootCopy = rootCopy.LeftChild;
                }
                else if (key > rootCopy.Key)
                {
                    if (rootCopy.RightChild == null)
                    {
                        return false;
                    }
                    rootCopy = rootCopy.RightChild;
                }
            }
            return false;
        }

        /// <summary>
        /// добавление в дерево значения 
        /// </summary>
        public void Insert(int key, T data)
        {
            throw new Exception();
        }

        /// <summary>
        /// удаление узла, в котором хранится значение
        /// </summary>
        public void Remove(int key)
        {
            if (root == null)
            {
                throw new ArgumentOutOfRangeException("Дерево пусто");
            }
            var rootCopy = root;
            bool isFind = false;
            while (isFind==false)
            {
                if (key < rootCopy.Key)
                {
                    if (rootCopy.LeftChild == null)
                    {
                        throw new ArgumentOutOfRangeException("Позиции не существует!");
                    }
                    rootCopy = rootCopy.LeftChild;
                }
                else if (key > rootCopy.Key)
                {
                    if (rootCopy.RightChild == null)
                    {
                        throw new ArgumentOutOfRangeException("Позиции не существует!");
                    }
                    rootCopy = rootCopy.RightChild;
                }

                //дошли до позиции, проверяем наследников
                if (rootCopy.Key == key)
                {
                    //узел - лист
                    if (rootCopy.LeftChild == null && rootCopy.RightChild == null)
                    {
                        if (rootCopy.Parent.LeftChild.Key == rootCopy.Key) //убираем ссылку от родителя к потомку
                            rootCopy.Parent.LeftChild = null;
                        else
                            rootCopy.Parent.RightChild = null;

                        rootCopy.Parent= null; //убираем ссылку от потомка к родителю
                    }
                    //нет левого, есть правый наследник
                    if (rootCopy.LeftChild == null && rootCopy.RightChild != null)
                    {
                        if (rootCopy.Parent.LeftChild.Key == rootCopy.Key) 
                            rootCopy.Parent.LeftChild = rootCopy.RightChild;
                        else
                            rootCopy.Parent.RightChild = rootCopy.RightChild;

                        rootCopy.RightChild.Parent = rootCopy.Parent; //ссылку правого потомка перекидываем на родителя удаляемого
                    }
                    //нет правого, есть левый
                    if (rootCopy.LeftChild != null && rootCopy.RightChild == null)
                    {
                        if (rootCopy.Parent.LeftChild.Key == rootCopy.Key)
                            rootCopy.Parent.LeftChild = rootCopy.LeftChild;
                        else
                            rootCopy.Parent.RightChild = rootCopy.LeftChild;

                        rootCopy.LeftChild.Parent = rootCopy.Parent;
                    }
                    //есть оба наследника
                    if (rootCopy.LeftChild != null && rootCopy.RightChild != null)
                    {
                        //нужно найти минимального потомка в правом дереве(у него не будет левого потомка)
                        //и переместить его на место удаляемого элемента
                        var rootCopyFind = rootCopy.RightChild; //Узел для спуска в правое дерево
                        while (rootCopyFind.LeftChild != null)
                        {
                            rootCopyFind = rootCopyFind.LeftChild; //Спускаемся в самый левый элемент
                        }
                        rootCopy.Value = rootCopyFind.Value;
                        rootCopy.Key = rootCopyFind.Key; //Значение самого левого элемента становиться вместо удаляемого узла
                        if (rootCopyFind.RightChild != null)
                        {
                            rootCopyFind.RightChild.Parent = rootCopyFind.Parent; //удаляем этот элемент
                        }
                        else
                        {
                            rootCopyFind.Parent.LeftChild = null;
                            rootCopyFind.Parent = null;
                        }
                    }
                    isFind = true;
                }
                
            }
            
        }

        //https://learnc.info/adt/binary_tree_traversal.html вывод деревьев

        /// <summary>
        /// Вывод в ширину
        /// </summary>
        public void PrintDepth()
        {
        }

        /// <summary>
        /// Сбалансировать дерево *
        /// </summary>
        public void Balance()
        {
        }


    }
}
