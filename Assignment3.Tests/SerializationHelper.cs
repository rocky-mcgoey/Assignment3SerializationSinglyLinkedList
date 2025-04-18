using System.Diagnostics;
using System.Text.Json;
using Assignment3.Utility;

namespace Assignment3.Tests
{
    public static class SerializationHelper
    {
        /// <summary>
        /// Serializes (encodes) users
        /// </summary>
        /// <param name="users">List of users</param>
        /// <param name="fileName"></param>
        public static void SerializeUsers(SLL<User> users, string fileName)
        {
            // Convert the linked list to a List<User> for easier serialization
            var userList = new List<User>();
            var currentNode = users.Head;

            while (currentNode != null)
            {
                userList.Add(currentNode.Data);
                currentNode = currentNode.Next;
            }

            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(userList, options);

            Debug.WriteLine("Serialized JSON: " + jsonString);
            File.WriteAllText(fileName, jsonString);
        }

        /// <summary>
        /// Deserializes (decodes) users
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>List of users</returns>
        public static SLL<User> DeserializeUsers(string fileName)
        {
            string jsonData = File.ReadAllText(fileName);
            Debug.WriteLine("JSON Data: " + jsonData);

            // Deserialize into a List<User>
            var userList = JsonSerializer.Deserialize<List<User>>(jsonData);

            // Convert the List<User> back into an SLL<User>
            var users = new SLL<User>();
            if (userList != null)
            {
                foreach (var user in userList)
                {
                    users.AddLast(user);
                }
            }

            return users;
        }
    }
}
