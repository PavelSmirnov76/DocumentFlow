using System.ComponentModel.DataAnnotations;

namespace DocumentFlow.Server.Models
{
    public class File
    {
        public long Id { get; set; }
        [Required]
        public string? FileName { get; set; }
        [Required]
        public string? FilePath { get; set; }
        public string? SignName { get; set; }
        public string? SignPath { get; set; }
    }
}
