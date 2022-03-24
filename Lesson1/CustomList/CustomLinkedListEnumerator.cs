using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.CustomList
{
    public class CustomLinkedListEnumerator<T> : IEnumerator<T> where T : IComparable<T>
    {
        private LinkedNode<T> _head;
        private LinkedNode<T> currentNode;
        public CustomLinkedListEnumerator(LinkedNode<T> head)
        {
            _head = head;
            currentNode = new LinkedNode<T>(default(T))
            {
                NextNode = head
            };

        }
        public T Current => currentNode.InfField;
        object IEnumerator.Current => Current;

        public void Dispose()
        {
           
        }

        public bool MoveNext()
        {
            if (currentNode.NextNode != null)
            {
                currentNode = currentNode.NextNode;
                return true;
            }
            else
                return false;
        }

        public void Reset()
        {
            currentNode = new LinkedNode<T>(default(T))
            {
                NextNode = _head
            };
        }
    }
}
