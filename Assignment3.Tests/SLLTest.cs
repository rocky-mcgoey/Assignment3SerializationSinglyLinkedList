using Assignment3.Utility;

namespace Assignment3.Tests
{
    public class SLLTests
    {

        public SLL<User> list;

        [SetUp]
        public void Setup()
        {
            list = new SLL<User>();
        }

        [Test]
        public void TestIsEmpty()
        {
            Assert.IsTrue(list.IsEmpty());
            Assert.AreEqual(0, list.GetCount());
        }

        [Test]
        public void TestAddFirst()
        {
            var user = new User(1, "Alice", "alice@example.com", "password");
            list.AddFirst(user);
            Assert.AreEqual(user, list.GetValue(0));
            Assert.AreEqual(1, list.GetCount());
        }

        [Test]
        public void TestAddLast()
        {
            var user = new User(2, "Bob", "bob@example.com", "password");
            list.AddLast(user);
            Assert.AreEqual(user, list.GetValue(0));
        }

        [Test]
        public void TestAddAtIndex()
        {
            var a = new User(1, "A", "a@example.com", "password");
            var b = new User(2, "B", "b@example.com", "password");
            list.AddLast(a);
            list.Add(b, 0);
            Assert.AreEqual(b, list.GetValue(0));
            Assert.AreEqual(a, list.GetValue(1));
        }

        [Test]
        public void TestReplace()
        {
            var a = new User(1, "Old", "old@example.com", "password");
            var b = new User(2, "New", "new@example.com", "password");
            list.AddLast(a);
            list.Replace(b, 0);
            Assert.AreEqual(b, list.GetValue(0));
        }

        [Test]
        public void TestRemoveFirst()
        {
            var user = new User(1, "First", "first@example.com", "password");
            list.AddLast(user);
            list.RemoveFirst();
            Assert.IsTrue(list.IsEmpty());
        }

        [Test]
        public void TestRemoveLast()
        {
            var a = new User(1, "Lasta", "LAsta@example.com", "password");
            var b = new User(2, "Lastb", "Lastb@example.com", "password");
            list.AddLast(a);
            list.AddLast(b);
            list.RemoveLast();
            Assert.AreEqual(1, list.GetCount());
            Assert.AreEqual(a, list.GetValue(0));
        }

        [Test]
        public void TestRemoveAtIndex()
        {
            var a = new User(1, "Lasta", "a@example.com", "password");
            var b = new User(2, "Lastb", "b@example.com", "password");
            var c = new User(3, "Lastc", "c@example.com", "password");
            list.AddLast(a);
            list.AddLast(b);
            list.AddLast(c);
            list.Remove(1);
            Assert.AreEqual(c, list.GetValue(1));
        }

        [Test]
        public void TestGetValue()
        {
            var user = new User(1, "Test", "test@example.com", "password");
            list.AddLast(user);
            Assert.AreEqual(user, list.GetValue(0));
        }

        [Test]
        public void TestIndexOf()
        {
            var a = new User(1, "FindIndex", "find@example.com", "password");
            list.AddLast(a);
            Assert.AreEqual(0, list.IndexOf(a));
        }

        [Test]
        public void TestContains()
        {
            var a = new User(1, "LookForMe", "look@example.com", "password");
            list.AddLast(a);
            Assert.IsTrue(list.Contains(a));
        }

        [Test]
        public void TestToArray()
        {
            list.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            list.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            list.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            list.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));

            User[] usersArray = list.ToArray();


            Assert.IsTrue(usersArray.Length == list.Count);

            Assert.AreEqual(list.Head.Data, usersArray[0]);

            int idx = 0;
            Node<User>? currentNode = list.Head;
            //while (list.Head != null)
            while (idx < list.Count)
            {
                Assert.AreEqual(currentNode.Data, usersArray[idx]);
                idx++;
                currentNode = currentNode.Next;
            }
        }
    }
}
