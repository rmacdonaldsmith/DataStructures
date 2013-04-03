using Lists.BinarySearchTree;
using NUnit.Framework;

namespace DataStructureTests.BinarySearchTree
{
    [TestFixture]
    public class when_searching_a_btree
    {
        private BinarySearchTree<int> _tree;

        [SetUp]
        public void given_a_btree_with_data()
        {
            _tree = new BinarySearchTree<int>(new []{12,43,6,7,34,24,16,456,1,4,9});
        }

        [Test]
        public void then_the_node_for_the_value_in_the_tree()
        {
            var node = _tree.Find(24);
            Assert.IsNotNull(node);
            Assert.AreEqual(24, node.Value);

            //try edge cases
            node = _tree.Find(12);
            Assert.IsNotNull(node);
            Assert.AreEqual(12, node.Value);

            node = _tree.Find(9);
            Assert.IsNotNull(node);
            Assert.AreEqual(9, node.Value);
        }

        [Test]
        public void then_null_if_we_cannot_find_the_value()
        {
            var node = _tree.Find(100);
            Assert.IsNull(node);
        }
    }
}
