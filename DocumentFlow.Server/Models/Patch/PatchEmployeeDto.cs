using DocumentFlow.Model;

namespace DocumentFlow.Server.Models.Patch
{
    public class PatchEmployeeDto : DtoBase
    {
        public Person? Person { get; set; }
        public Position? Position { get; set; }
    }
}
