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
                        .Include(c => c.Address)
                        .Include(c => c.Telephones)
                         .OrderBy(contact => contact.Id)
                         .Where(c => c.Id == contactId);

            return query.FirstOrDefault();
        }
        public async Task<IEnumerable<Contact>> GetContactsByNameAsync(string Name)
        {
            IQueryable<Contact> query = _context.Contacts;


            query = query.AsNoTracking()
                         .OrderBy(contact => contact.Id)
                         .Where(a => a.Name.ToUpper().Contains(Name.ToUpper()) ||
                                     a.LastName.ToUpper().Contains(Name.ToUpper()));

            return await query.ToListAsync();
        }
        public async Task<IEnumerable<Contact>> GetContactsByPhoneAsync(string Number)
        {
            IQueryable<Contact> query = _context.Contacts;


            query = query.AsNoTracking()
                         .OrderBy(contact => contact.Id)
                         .Where(a => a.Telephones.Any(t => t.Number.Contains(Number)));

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Address>> GetAllAddressesAsync()
        {
            IQueryable<Address> query = _context.Addresses;

            query = query.AsNoTracking().OrderBy(Address => Address.Id);

            return await query.ToListAsync();
        }

        public Address GetAddressById(int addressId)
        {
            IQueryable<Address> query = _context.Addresses;
            query = query.AsNoTracking()
                         .OrderBy(address => address.Id)
                         .Where(c => c.Id == addressId);

            return query.FirstOrDefault();
        }       

        public async Task<IEnumerable<Telephone>> GetAllTelephonesAsync()
        {
            IQueryable<Telephone> query = _context.Telephones;

            query = query.AsNoTracking().OrderBy(Address => Address.Id);

            return await query.ToListAsync();
        }
        
    }
}
