using BLL.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BLL.UnitTest
{
    public class ContactRepositoryTest
    {
        public ContactRepository contactReporisory { get; set; }

        public ContactRepositoryTest()
        {
            contactReporisory = new ContactRepository();
        }

        [TestMethod]
        public void CreateContactTest()
        {
            var testModel = GetContactModel();
            var id = contactReporisory.Add(testModel);
            var dbModel = contactReporisory.Get(id);

            Assert.AreEqual(testModel, dbModel);
        }

        [TestMethod]
        public void UpdateContactTest()
        {
            var testModel = contactReporisory.Get().First();
            testModel.FirstName = "Updated";

            contactReporisory.Update(testModel);

            var dbModel = contactReporisory.Get(testModel.Id);

            Assert.AreEqual(testModel, dbModel);
        }

        [TestMethod]
        public void DeleteContactTest()
        {
            var testModel = contactReporisory.Get().First();

            contactReporisory.Delete(testModel.Id);

            var dbModel = contactReporisory.Get(testModel.Id);

            Assert.AreEqual(dbModel, null);
        }


        [TestMethod]
        public void GetContactTest()
        {
            var testModel = contactReporisory.Get().First();

            var dbModel = contactReporisory.Get(testModel.Id);

            Assert.AreNotEqual(dbModel, null);
        }

        [TestMethod]
        public void GetAllContactTest()
        {
            var testModel = contactReporisory.Get().First();

            var dbModel = contactReporisory.Get(testModel.Id);

            Assert.AreNotEqual(dbModel, null);
        }

        private static Contact GetContactModel()
        {
            return new Contact()
            {
                Email = "vw1091@gmail.com",
                FirstName = "Vaibhav",
                LastName = "Wattamwar",
                PhoneNumber = "1111122222"
            };
        }
    }
}
