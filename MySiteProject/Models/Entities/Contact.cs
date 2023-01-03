using System.ComponentModel.DataAnnotations;

namespace MySiteProject.Models.Entities
{
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Surname { get; set; }
        [MaxLength(255)]
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
