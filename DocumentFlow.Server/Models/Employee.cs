using DocumentFlow.Server.Models;
using System.ComponentModel.DataAnnotations;

namespace DocumentFlow.Model
{
    public class Employee
    {
        public long Id { get; set; }
        [Required]
        public long PersonId { get; set; }
        public Person? Person { get; set; }
        [Required]
        public long PositionId { get; set; }
        public Position? Position { get; set; }     
    } 
}
