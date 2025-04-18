using System.Diagnostics;
using Assignment3.Utility;

namespace Assignment3.Tests
{
    public class SerializationTests
    {
        private SLL<User> users;
        //private ILinkedListADT users;
        //private readonly string testFileName = "test_users.bin";
        private readonly string testFileName = "test_users.json";

        [SetUp]
        public void Setup()
        {
            // Uncomment the following line
            this.users = new SLL<User>();

            users.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            users.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            users.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            users.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));
        }

        [TearDown]
        public void TearDown()
        {
            this.users.Clear();
        }

        /// <summary>
        /// Tests the object was serialized.
        /// </summary>
        [Test]
        public void TestSerialization()
        {
            SerializationHelper.SerializeUsers(users, testFileName);
            Assert.IsTrue(File.Exists(testFileName));
        }

        /// <summary>
        /// Tests the object was deserialized.
        /// </summary>
        [Test]
        public void TestDeSerialization()
        {
            SerializationHelper.SerializeUsers(users, testFileName);
            Debug.WriteLine("USERS" + users);
            SLL<User> deserializedUsers = SerializationHelper.DeserializeUsers(testFileName);
            Debug.WriteLine("DESERIALIKJEFHKJFKJERJKLFGBJMER" + deserializedUsers);
            Assert.IsTrue(users.GetCount() == deserializedUsers.GetCount());

            for (int i = 0; i < users.GetCount(); i++)
            {
                User expected = users.GetValue(i);
                User actual = deserializedUsers.GetValue(i);

                Assert.AreEqual(expected.Id, actual.Id);
                Assert.AreEqual(expected.Name, actual.Name);
                Assert.AreEqual(expected.Email, actual.Email);
                Assert.AreEqual(expected.Password, actual.Password);
            }
        }
    }
}