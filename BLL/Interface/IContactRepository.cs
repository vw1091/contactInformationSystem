using BLL.Model;
using System.Collections.Generic;

namespace BLL.Interface
{
    public interface IContactRepository
    {
        int Add(Contact contactInformation);
        bool Update(Contact contactInformation);
        bool Delete(int id);
        Contact Get(int id);
        IEnumerable<Contact> Get();
    }
}
