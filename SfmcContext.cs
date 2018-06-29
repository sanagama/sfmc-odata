
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SfmcOdataDemo.Models;

namespace SfmcOdataDemo
{
    public class SfmcContext : DbContext
    {
        private readonly ILogger _logger;

        public DbSet<Account> Accounts { get; set; }

        public DbSet<BusinessUnit> BusinessUnits { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Email> Emails { get; set; }

        public DbSet<TextMessage> TextMessages { get; set; }

        public DbSet<PushNotification> PushNotifications { get; set; }

        public SfmcContext(ILogger<SfmcContext> logger) : base()
        {
            _logger = logger;
        }
        public SfmcContext(DbContextOptions options, ILogger<SfmcContext> logger) : base(options)
        {
            _logger = logger;
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Nothing to do currently
        }
    }
}