
using System.ComponentModel.DataAnnotations;

namespace SfmcOdataDemo.Models
{
    public class Email
    {
        public Email()
        {
        }
    
        [Key]
        public int EmailId { get; set; }
    
        [Required]
        public string Name { get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; }

        [Required]
        public string HtmlBody { get; set; }

        public string TextBody { get; set; }
    }
}