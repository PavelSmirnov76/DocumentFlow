using DocumentFlow.Server.Models;
using File = DocumentFlow.Server.Models.File;

namespace DocumentFlow.Model
{
    public class InternalDocument
    {
        public long Id { get; set; }
        public string? Header { get; set; }
        public string? Description { get; set; }
        public long AuthorId { get; set; }
        public Employee? Author { get; set; }
        public long StateId { get; set; }
        public State? State { get; set; }
        public DateTime? Created { get; set; }
        public long? FileId { get; set; }
        public File? File { get; set; }
    }
}