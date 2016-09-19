using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgeDemo.Test
{
    [TestClass]
    public class PersonTest
    {
        [TestMethod]
        public void ConstructingAPersonSetsTheRightPubliclyAvailableFields()
        {
            // Arrange
            Person pim = new Person("Pim", 21);

            // Act
            string name = pim.Name;
            int age = pim.Age;

            // Assert
            Assert.AreEqual("Pim", name);
            Assert.AreEqual(21, age);
        }

        [TestMethod]
        public void PersonAgesOnBirthDay()
        {
            // Arrange
            Person pim = new Person("Pim", 21);
            
            // Act
            pim.CelebrateBirthday();

            // Assert
            Assert.AreEqual(22, pim.Age);
        }

        [TestMethod]
        public void PersonInvitesHisFriendsOnBirthday()
        {
            // Arrange
            Person pim = new Person("Pim", 21);
            BirthdayOrganiserMock organiser = new BirthdayOrganiserMock();

            // Act
            pim.BirthDayHandlers += organiser.InviteFriendsToComeOver;
            pim.CelebrateBirthday();

            // Assert
            Assert.IsTrue(organiser.FriendsAreInvited);
        }

        [TestMethod]
        public void PersonsNewAgeIsOneMoreThanOldAgeAndHasSameName()
        {
            // Arrange
            int currentAge = 21;
            string name = "Pim";

            Person pim = new Person(name, currentAge);
            BirthdayOrganiserMock organiser = new BirthdayOrganiserMock();

            // Act
            pim.BirthDayHandlers += organiser.InviteFriendsToComeOver;
            pim.CelebrateBirthday();

            // Assert
            Assert.AreEqual(currentAge, organiser.Arguments.OldAge);
            Assert.AreEqual(currentAge + 1, organiser.Arguments.NewAge);
            Assert.AreEqual(name, organiser.Arguments.Name);
        }

        [TestMethod]
        public void PersonsAgeCanBeChanged()
        {
            // Arrange
            int currentAge = 21;
            Person pim = new Person("Pim", currentAge);

            // Act
            pim.ChangeAge(18);

            // Assert
            Assert.AreEqual(39, pim.Age);
        }

        [TestMethod]
        public void PersonsAgeCanBeChangedToYoungerAge()
        {
            // Arrange
            int currentAge = 21;
            Person pim = new Person("Pim", currentAge);

            // Act
            pim.ChangeAge(-18);

            // Assert
            Assert.AreEqual(3, pim.Age);
        }

        [TestMethod]
        public void BirthdayUsesAgeChangedInternally()
        {
            // Arrange
            Person pim = new Person("Pim", 21);
            SalaryManagerMock manager = new SalaryManagerMock();

            // Act
            pim.BirthDayHandlers += manager.ChangeSalary;
            pim.CelebrateBirthday();

            // Assert
            Assert.IsTrue(manager.SalaryHasChanged);
        }
    }
}
