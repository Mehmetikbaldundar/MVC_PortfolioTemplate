using System.ComponentModel.DataAnnotations;

namespace MySiteProject.Models.Entities
{
    public class AboutMe
    {
        [Key]
        public int AboutMeID { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DescriptionDate { get; set; }
        [MaxLength(255)]
        public string? DescriptionPhoto { get; set; }
    }
}
