using System.ComponentModel.DataAnnotations;

namespace MySiteProject.Models.Entities
{
    public class AdminTab
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(50)]
        public string Username { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }
    }
}
