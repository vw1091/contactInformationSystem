using BLL.Interface;
using System;
using System.Collections.Generic;
using BLL.Model;
using DataAccess;
using System.Linq;
using BLL.Model.Utils;

namespace BLL
{
    public class ContactRepository : IContactRepository
    {
        public int Add(Contact contactInformation)
        {
            using (var dbContext = new EvolentDemo())
            {
                ContactInformation dbContact = contactInformation.ToDB();

                dbContext.ContactInformations.Add(dbContact);

                dbContext.SaveChanges();

                return dbContact.Id;
            }
        }

        public bool Delete(int id)
        {
            using (var dbContext = new EvolentDemo())
            {
                var dbContact = dbContext.ContactInformations.FirstOrDefault(x => x.Id == id);

                if (dbContact == null)
                    return false;

                dbContact.IsDeleted = true;

                dbContext.SaveChanges();
            }
            return true;
        }

        public IEnumerable<Contact> Get()
        {
            using (var dbContext = new EvolentDemo())
            {
                var contacts = (from contact in dbContext.ContactInformations
                                where !contact.IsDeleted
                                select contact
                                ).ToList();

                return contacts.Select(x => x.ToVM());
            }
        }

        public Contact Get(int id)
        {
            using (var dbContext = new EvolentDemo())
            {

                var contact = (from dbContact in dbContext.ContactInformations
                               where !dbContact.IsDeleted && dbContact.Id == id
                               select dbContact
                               ).FirstOrDefault();

                return contact.ToVM();
            }
        }

        public bool Update(Contact contactInformation)
        {
            using (var dbContext = new EvolentDemo())
            {
                var dbContact = dbContext.ContactInformations.FirstOrDefault(x => x.Id == contactInformation.Id);

                if (dbContact == null)
                    return false;

                dbContact.Email = contactInformation.Email;
                dbContact.FirstName = contactInformation.FirstName;
                dbContact.LastName = contactInformation.LastName;
                dbContact.PhoneNumber = contactInformation.PhoneNumber;

                dbContext.SaveChanges();
            }

            return true;
        }
    }
};