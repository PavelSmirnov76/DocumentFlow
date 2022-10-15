namespace DocumentFlow.Server.Models
{
    public class File
    {
        public long Id { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public string? SignName { get; set; }
        public string? SignPath { get; set; }
    }
}
