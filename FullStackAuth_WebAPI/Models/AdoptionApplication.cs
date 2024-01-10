using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FullStackAuth_WebAPI.Models
{
    public class AdoptionApplication
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime ApplicationDate { get; set; } // Assuming Date should be DateTime

        [Required]
        public string Status { get; set; } // "Pending", "Approved", "Denied"


        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Dog")]
        public int DogId { get; set; }
        public Dog Dog { get; set; }






    }
}
