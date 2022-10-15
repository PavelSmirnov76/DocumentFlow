using DocumentFlow.Server.Models;

namespace DocumentFlow.Model
{
    public class Employee
    {
        public long Id { get; set; }

        public long PersonId { get; set; }
        public Person? Person { get; set; }
        public long PositionId { get; set; }
        public Position? Position { get; set; }      
        public bool IsSignatory { set; get; }
        public bool IsСoordinating { get; set; }
        public bool IsAddressee  { get; set; }
    }
}
