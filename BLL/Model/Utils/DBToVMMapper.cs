using DataAccess;

namespace BLL.Model.Utils
{
    public static class DBToVMMapper
    {
        public static Contact ToVM(this ContactInformation dbContact)
        {
            return new Contact
            {
                Email = dbContact.Email,
                FirstName = dbContact.FirstName,
                LastName = dbContact.LastName,
                Id = dbContact.Id,
                PhoneNumber = dbContact.PhoneNumber
            };
        }
    }
}
