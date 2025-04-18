using System;
using System.Text.Json.Serialization;

namespace Assignment3.Utility
{
    [Serializable]
    public class Node<T>
    {
        //public User Data { get; set; }
        [JsonInclude]
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        //public Node(User data)
        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }
}
