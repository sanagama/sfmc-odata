using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using SfmcOdataDemo.Models;

namespace SfmcOdataDemo
{
    internal class SfmcDemoInitializer
    {
        private SfmcContext _context;
        public SfmcDemoInitializer(SfmcContext context)
        {
            _context = context;
        }
        
        public void Initialize()
        {
            // Drop & recreate the database at each demo run
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            // Create seed data for demo
            SeedData();
        }

        private void SeedData()
        {
            // Account
            var account = new Account { AccountId = 1, Name = "Peh's Bicycle Shop"};
            _context.Accounts.Add(account);
            _context.SaveChanges();

            var contacts = new List<Contact>
            {
                new Contact
                {
                    ContactId = 1,
                    Account = account,
                    Name = "Syam"
                },
                new Contact
                {
                    ContactId = 2,
                    Account = account,
                    Name = "Sanjay",
                },
                new Contact
                {
                    ContactId = 3,
                    Account = account,
                    Name = "Gautam"
                }
            };

            _context.Contacts.AddRange(contacts);
            _context.SaveChanges();
        }
    }
}