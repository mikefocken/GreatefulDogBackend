using Microsoft.AspNetCore.Identity;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;

namespace FullStackAuth_WebAPI.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool Adopter { get; set; }
        public bool Admin { get; set; }
        public bool Volunteer { get; set; }






    }





}









