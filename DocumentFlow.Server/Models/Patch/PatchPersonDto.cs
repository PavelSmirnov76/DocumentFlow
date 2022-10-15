namespace DocumentFlow.Server.Models.Patch
{
    public class PatchPersonDto : PatchDtoBase
    {
        public string? FullName { get; set; }
        public string? Sex { get; set; }
        public DateTime? DateBirth { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
