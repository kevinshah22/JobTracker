using System.ComponentModel.DataAnnotations;

namespace JobTracker.Data.Models
{
    public class Position
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public int UserId { get; set; }
    }
}
