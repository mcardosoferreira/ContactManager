using ContactManager.Data.Context;
using ContactManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Data.Repositories
{
    public class Repository : IRepository
    {
        private readonly ContactManagerContext _context;
        public Repository(ContactManagerContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity); ;
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public async Task<IEnumerable<Contact>> GetAllContactsAsync()
        {
            IQueryable<Contact> query = _context.Contacts;

            query = query.AsNoTracking()
                .Include(c => c.Address)
                .Include(c => c.Telephones)
                .OrderBy(contact => contact.Id);

            return await query.ToListAsync();
        }

        public Contact GetContactById(int contactId)
        {
            IQueryable<Contact> query = _context.Contacts;
            query = query.AsNoTracking()
                         .OrderBy(contact => contact.Id)
                         .Where(c => c.Id == contactId);

            return query.FirstOrDefault();
        }
    }
}
