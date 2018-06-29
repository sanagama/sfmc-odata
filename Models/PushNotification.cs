
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SfmcOdataDemo.Models
{
    public class PushNotification
    {
        public PushNotification()
        {
        }
    
        [Key]
        public int MessageKey { get; set; }
    
        public int MID { get; set; }

        [ForeignKey("MID")]
        public BusinessUnit BusinessUnit { get; set; }
        public string TextBody { get; set; }
    }
}