using ContactManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ContactManager.Data.Context
{

    public class ContactManagerContext : DbContext
    {
        public ContactManagerContext(DbContextOptions<ContactManagerContext> options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Telephone> Telephones { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Contact>().HasMany(c => c.Telephones).WithOne(t => t.Contact);
            builder.Entity<Address>().HasOne(a => a.Contact).WithOne(c => c.Address).HasForeignKey<Contact>(c => c.AddressId);


            builder.Entity<Contact>()
                 .HasData(new List<Contact>(){
                    new Contact(1, "Lauro", "Oliveira", "lauro@oliveira.com", new DateTime(2005,05,28), 2),
                    new Contact(2, "Roberto", "Soares", "Roberto@Soares.com", new DateTime(2005,05,28), 3),
                    new Contact(3, "Ronaldo", "Marconi", "Ronaldo@Marconi.com", new DateTime(2005, 05, 28), 4),
                    new Contact(4, "Rodrigo", "Carvalho", "Rodrigo@Carvalho.com", new DateTime(2005, 05, 28), 5),
                    new Contact(5, "Alexandre", "Montanha", "Alexandre@Montanha.com", new DateTime(2005, 05, 28), 1),
                 });
            builder.Entity<Address>()
                 .HasData(new List<Address>(){
                    new Address(1, "Castelo Branco", "salvador", "bahia", "casa 29" ),
                    new Address(2, "Stiep", "salvador", "bahia", "casa 29" ),
                    new Address(3, "Rio Vermelho", "salvador", "bahia", "casa 29"),
                    new Address(4, "Federação", "salvador", "bahia", "casa 29"),
                    new Address(5, "Barra", "salvador", "bahia", "casa 29")
                 });
            builder.Entity<Telephone>()
                 .HasData(new List<Telephone>(){
                    new Telephone(1, 2, "123456"),
                    new Telephone(2, 3, "654321"),
                    new Telephone(3, 1, "124578"),
                    new Telephone(4, 5, "134679"),
                    new Telephone(5, 4, "875421"),
                    new Telephone(6, 2, "976431"),
                    new Telephone(7, 1, "258741"),
                    new Telephone(8, 1, "147963"),
                 });
        }
    }
}
