using System.ComponentModel.DataAnnotations;

namespace MySiteProject.Models.Entities
{
    public class ProjectInfo
    {
        [Key]
        public int ProjectID { get; set; }
        [MaxLength(150)]
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public DateTime ProjectDate { get; set; }
        [MaxLength(255)]
        public string? ProjectPhoto { get; set; }
    }
}
