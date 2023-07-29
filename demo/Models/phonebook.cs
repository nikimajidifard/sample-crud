using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class phonebook
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}