using System.ComponentModel.DataAnnotations;

namespace DocumentFlow.Server.Models
{
    public class State
    {
        public long Id { get; set; }
        [Required]
        public string? Name { get; set; }
    }
}
