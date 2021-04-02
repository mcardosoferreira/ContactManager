using ContactManager.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactManager.Data.Repositories
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        //Contacts
        Task<IEnumerable<Contact>> GetAllContactsAsync();
        Contact GetContactById(int contactId);

    }
}
