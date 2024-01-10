using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Org.BouncyCastle.Bcpg;
using System.Runtime.InteropServices;

namespace FullStackAuth_WebAPI.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }

        [ForeignKey ("Dog")]
        public int DogId { get; set; }
        public Dog Dog { get; set; }



    }
}
