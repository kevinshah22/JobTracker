using System.ComponentModel.DataAnnotations;

namespace JobTracker.ViewModel
{
    public class JobApplicationModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter job title")]
        public string JobTitle { get; set; }

        [Required(ErrorMessage = "Please select company Id")]
        public int CompanyId { get; set; }
        public string? JobLink { get; set; }
        public string? Position { get; set; }

        [Required(ErrorMessage = "Please enter job description")]
        public string JobDescription { get; set; }
        
        public string SalaryRange { get; set; }
        
        [Required(ErrorMessage = "Please enter job status")]
        public byte JobStatus { get; set; }
        
        public DateTime ApplicationDate { get; set; }
        
        public string? RejectionReason { get; set; }
    }
}
