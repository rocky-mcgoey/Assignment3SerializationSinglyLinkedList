using System;
using System.Text.Json.Serialization;

namespace Assignment3.Utility
{

    [Serializable]
    public class SLL<T> : ILinkedListADT
    {
        [JsonInclude]
        public Node<User> Head;
        [JsonInclude]
        public int Count;

        public SLL()
        {
            Head = null;
            Count = 0;
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public void Clear()
        {
            Head = null;
            Count = 0;
        }

        public void AddLast(User value)
        {
            Node<User> newNode = new Node<User>(value);
            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                Node<User> current = Head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
            Count++;
        }

        public void AddFirst(User value)
        {
            Node<User> newNode = new Node<User>(value);
            newNode.Next = Head;
            Head = newNode;
            Count++;
        }

        public void Add(User value, int index)
        {
            if (index < 0 || index > Count)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            if (index == 0)
            {
                AddFirst(value);
            }
            else
            {
                Node<User> newNode = new Node<User>(value);
                Node<User> current = Head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                newNode.Next = current.Next;
                current.Next = newNode;
                Count++;
            }
        }

        public void Replace(User value, int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            Node<User> current = Head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            current.Data = value;
        }

        public int GetCount()
        {
            return Count;
        }

        public void RemoveFirst()
        {
            if (Head == null)
            {
                throw new InvalidOperationException("Cannot remove from an empty list.");
            }
            Head = Head.Next;
            Count--;
        }

        public void RemoveLast()
        {
            if (Head == null)
            {
                throw new InvalidOperationException("Cannot remove from an empty list.");
            }

            if (Head.Next == null)
            {
                Head = null;
            }
            else
            {
                Node<User> current = Head;
                while (current.Next.Next != null)
                {
                    current = current.Next;
                }
                current.Next = null;
            }
            Count--;
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            if (index == 0)
            {
                RemoveFirst();
            }
            else
            {
                Node<User> current = Head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                current.Next = current.Next.Next;
                Count--;
            }
        }

        public User GetValue(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            Node<User> current = Head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            return current.Data;
        }

        public int IndexOf(User value)
        {
            Node<User> current = Head;
            int index = 0;

            while (current != null)
            {
                if (current.Data.Equals(value))
                {
                    return index;
                }
                current = current.Next;
                index++;
            }

            return -1;
        }

        public bool Contains(User value)
        {
            return IndexOf(value) != -1;
        }

        public User[] ToArray()
        {
            User[] array = new User[Count];
            Node<User> current = Head;
            int index = 0;
            while (current != null)
            {
                array[index++] = current.Data;
                current = current.Next;
            }
            return array;
        }
    }
}
