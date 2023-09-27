using System.ComponentModel.DataAnnotations;

namespace EventLogsAPI.Models
{
    public class EventLogs
    {
        [Key]
        public int EventId { get; set; }

        [Required]
        public DateTime EventDate { get; set; }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; }

        [Required]
        [MaxLength(6)]
        public string EventType { get; set; }
    }
}
