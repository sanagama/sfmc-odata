
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.OData.Builder;

namespace SfmcOdataDemo.Models
{
    public class Account
    {
        public Account()
        {
            Contacts = new Collection<Contact>();
            Emails = new Collection<Email>();
        }
    
        [Key]
        public int AccountId { get; set; }
    
        [Required]
        public string Name { get; set; }
    
        public virtual ICollection<Email> Emails { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }
    }
}