using DocumentFlow.Model;

namespace DocumentFlow.Server.Models.Patch
{
    public class PatchEmployeeDto : PatchDtoBase
    {
        public Person? Person { get; set; }
        public Position? Position { get; set; }
        public bool IsSignatory { set; get; }
        public bool IsСoordinating { get; set; }
        public bool IsAddressee { get; set; }
    }
}
