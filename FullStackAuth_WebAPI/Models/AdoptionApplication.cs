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
        public int UserId { get; set; }

        [Required]
        public int DogId { get; set; }






    }
}
