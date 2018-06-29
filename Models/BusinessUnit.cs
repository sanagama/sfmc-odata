
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.OData.Builder;

namespace SfmcOdataDemo.Models
{
    public class BusinessUnit
    {
        public BusinessUnit()
        {
            Contacts = new Collection<Contact>();
            Emails = new Collection<Email>();
            TextMessages = new Collection<TextMessage>();
            PushNotifications = new Collection<PushNotification>();
        }
    
        [Key]
        public int MID { get; set; }
    
        [Required]
        public string Name { get; set; }
    
        public int AccountId { get; set; }
        public Account Account { get; set; }

        public virtual ICollection<Email> Emails { get; set; }

        public virtual ICollection<TextMessage> TextMessages { get; set; }

        public virtual ICollection<PushNotification> PushNotifications { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }
    }
}