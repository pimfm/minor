using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryTreeDemo.Test
{
    [TestClass]
    public class BinaryTreeTest
    {
        [TestMethod]
        public void ANewlyPlantedTreeDoesNotHaveBranchesAndLeavesYet()
        {
            // Arrange
            BinaryTree<int> tree = BinaryTree<int>.PlantNewTree();

            // Act
            int amount = tree.AmountOfBranchesAndLeaves();
            int depth  = tree.DistanceToFurthestLeave();

            // Assert
            Assert.AreEqual(amount, 0);
            Assert.AreEqual(depth, 0);
        }

        [TestMethod]
        public void AddingAValueToTheTreeIncreasesAmountOfBranchesAndLeaves()
        {
            // Arrange
            BinaryTree<int> tree = BinaryTree<int>.PlantNewTree();

            // Act
            tree = tree.Add(10);

            // Assert
            Assert.AreEqual(1, tree.AmountOfBranchesAndLeaves());
            Assert.AreEqual(1, tree.DistanceToFurthestLeave());
        }

        [TestMethod]
        public void AddingOneSmallerAndOneBigger()
        {
            // Arrange
            BinaryTree<int> tree = BinaryTree<int>.PlantNewTree();

            // Act
            tree = tree.Add(10);
            tree = tree.Add(11);
            tree = tree.Add(9);

            // Assert
            Assert.AreEqual(3, tree.AmountOfBranchesAndLeaves());
            Assert.AreEqual(2, tree.DistanceToFurthestLeave());
        }
    }
}
