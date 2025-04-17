using System.ComponentModel.DataAnnotations;

namespace JobTracker.ViewModel
{
    /// <summary>
    /// Company model
    /// </summary>
    public class CompanyModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter company name")]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
