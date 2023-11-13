using System.ComponentModel.DataAnnotations;

namespace StanceNation_1.Models
{
    public class EventsModel
    {
        [Key]
        public string eventName { get; set; }
        public string eventDate { get; set; }
        public byte[] eventImage { get; set; }
        public string eventLocation { get; set; } 
        public string eventPrice { get; set; }
        public string eventPrice2 { get; set; }
        public string eventTime { get; set; }
    }
}
