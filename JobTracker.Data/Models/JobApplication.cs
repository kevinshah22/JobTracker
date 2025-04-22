using System.ComponentModel.DataAnnotations;

namespace JobTracker.Data.Models
{
    public class JobApplication
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string JobTitle { get; set; }
        [Required]
        public int CompanyId { get; set; }
        public string? JobLink { get; set; }
        public string? Position { get; set; }
        [Required]
        public string JobDescription { get; set; }
        public string? SalaryRange { get; set; }
        [Required]
        public byte JobStatus { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string? RejectionReason { get; set; }
        public int UserId { get; set; }
    }
}
