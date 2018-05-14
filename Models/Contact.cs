
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.OData.Builder;

namespace SfmcOdataDemo.Models
{
    public class Contact
    {
        public Contact()
        {
        }
    
        [Key]
        public int ContactId { get; set; }
    
        [Required]
        public string Name { get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}