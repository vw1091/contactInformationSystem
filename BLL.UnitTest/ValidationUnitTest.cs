using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using BLL.Model;
using FluentValidation;
using System.Linq;

namespace BLL.UnitTest
{
    public class ValidationUnitTest
    {   

        [TestMethod]
        public void ValidationFirstNameTest()
        {
            Contact contact = GetContactModel();

            contact.FirstName = "%$5454";

            var validator = new ContactValidator();

            var result = validator.Validate(contact);

            Assert.Equals(result.Errors.First().ErrorCode.Equals(ResponseCodes.InvalidFirstName), true);
        }

        [TestMethod]
        public void ValidationLastNameTest()
        {
            Contact contact = GetContactModel();

            contact.LastName = "%%343";

            var validator = new ContactValidator();

            var result = validator.Validate(contact);

            Assert.Equals(result.Errors.First().ErrorCode.Equals(ResponseCodes.InvalidFirstName), true);
        }

        [TestMethod]
        public void ValidationEmailTest()
        {
            Contact contact = GetContactModel();

            contact.Email = "Vaibhav@gma";
            var validator = new ContactValidator();

            var result = validator.Validate(contact);

            Assert.Equals(result.Errors.First().ErrorCode.Equals(ResponseCodes.InvalidFirstName), true);
        }

        [TestMethod]
        public void ValidationPhoneTest()
        {
            Contact contact = GetContactModel();

            contact.Email = "12121121tt";
            var validator = new ContactValidator();

            var result = validator.Validate(contact);

            Assert.Equals(result.Errors.First().ErrorCode.Equals(ResponseCodes.InvalidFirstName), true);
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
