using DataAccess;

namespace BLL.Model.Utils
{
    public static class VMToDbMapper
    {
        public static ContactInformation ToDB(this Contact contactInformation)
        {
            return new ContactInformation
            {
                Email = contactInformation.Email,
                FirstName = contactInformation.FirstName,
                LastName = contactInformation.LastName,
                PhoneNumber = contactInformation.PhoneNumber
            };
        }

    }
}
