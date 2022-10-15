namespace DocumentFlow.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }      
        public string? Patronymic { get; set; }
        public string? Sex { get; set; }
        public DateTime? DateBirth { get; set; }
        public string? PhoneNumber { get; set; }

        public Employee(string firstName, string lastName, string patronymic, string sex, DateTime? dateBirth, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Patronymic = patronymic;
            Sex = sex;
            DateBirth = dateBirth;
            PhoneNumber = phoneNumber;
        }

        public Employee() 
        {

        }
    }
}
