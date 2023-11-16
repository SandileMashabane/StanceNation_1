using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace StanceNation_1.Models
{
    public class EventsModel
    {
        [Key]
        public string eventName { get; set; }
        public DateTime eventDate { get; set; }
        public string eventImage { get; set; }
        public string eventLocation { get; set; } 
        public string eventPrice { get; set; }
        public string eventPrice2 { get; set; }

        [NotMapped]
        [Display(Name = "Upload Image")]
        
        public IFormFile ImageFile { get; set; }
    }
}
