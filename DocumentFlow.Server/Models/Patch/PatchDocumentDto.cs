using DocumentFlow.Model;

namespace DocumentFlow.Server.Models.Patch
{
    public class PatchDocumentDto : DtoBase
    {
        public string? Hedder { get; set; }
        public Employee? Author { get; set; }
        public Employee? Signatory { get; set; }
        public List<Employee>? Сoordinating { get; set; }
        public Employee? Addressee { get; set; }
        public State? State { get; set; }
        public DateTime? Created { get; set; }
    }
}
