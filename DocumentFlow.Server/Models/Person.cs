using System.ComponentModel.DataAnnotations;

namespace DocumentFlow.Model
{
    public class Person
    {
        private string fullName = "";

        public long Id { get; set; }
        [Required]
        public string FullName { get => fullName; set => fullName = value; }
        public string? Sex { get; set; }
        public DateTime? DateBirth { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
