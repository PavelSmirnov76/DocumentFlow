namespace DocumentFlow.Model
{
    public class Document
    {
        public int Id { get; set; }
        public string? Hedder { get; set; }
        public Employee? Author { get; set; }
        public Employee? Signatory { get; set; } // Подписант
        public Employee? Сoordinating { get; set; } // Согласующие

    }
}