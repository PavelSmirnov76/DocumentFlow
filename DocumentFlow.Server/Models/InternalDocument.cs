using DocumentFlow.Server.Models;
using System.ComponentModel.DataAnnotations;
using File = DocumentFlow.Server.Models.File;

namespace DocumentFlow.Model
{
    public class InternalDocument
    {
        public long Id { get; set; }
        [Required]
        public string? Header { get; set; }
        public string? Description { get; set; }
        [Required]
        public long AuthorId { get; set; }
        [Required]
        public Employee? Author { get; set; }
        public long StateId { get; set; }
        public State? State { get; set; }
        public long? FileId { get; set; }
        public File? File { get; set; }
    }
}