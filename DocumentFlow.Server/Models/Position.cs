using System.ComponentModel.DataAnnotations;

namespace DocumentFlow.Server.Models
{
    public class Position
    {
        private string name = "";

        public long Id { get; set; }
        [Required]
        public string Name { get => name; set => name = value; }
        public string? Description { set; get; }
    }
}
