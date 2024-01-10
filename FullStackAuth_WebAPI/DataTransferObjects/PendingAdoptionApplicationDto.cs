using FullStackAuth_WebAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace FullStackAuth_WebAPI.DataTransferObjects
{
    public class PendingAdoptionApplicationDto
    {
        public string ApplicationId { get; set; }
        public DateTime Date { get; set; }
        public string status { get; set; }

        public int DogId  {get;set;}
        public string UserId { get; set; }
        public string DogBioForDisplayDto { get; set; }
    }
}
