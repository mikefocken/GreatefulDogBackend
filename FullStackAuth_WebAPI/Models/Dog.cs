using System.ComponentModel.DataAnnotations;

namespace FullStackAuth_WebAPI.Models
{
    public class Dog
    {
        [Key]
        public int Id { get; set; }
                
        public string Name { get; set; }
       
        public  int Age { get; set; }
        public string Breed { get; set; }
        
        public string Gender { get; set; }
        
        public string Size { get; set; }
        
        public float Weight { get; set; }
        
        public string EnergyLevel { get; set; } // "High, Medium and Low" i will need to figure that out.
        
        public string Color { get; set; }

        public DateTime AdoptionDate {get;set;}
        public bool IsAdopted { get; set; } = false;

        public byte[] Image { get; set; }

    }
}
