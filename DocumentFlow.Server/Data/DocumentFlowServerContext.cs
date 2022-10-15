using Microsoft.EntityFrameworkCore;
using DocumentFlow.Model;
using DocumentFlow.Server.Models;
using File = DocumentFlow.Server.Models.File;

namespace DocumentFlow.Server.Data
{
    public class DocumentFlowServerContext : DbContext
    {
        public DocumentFlowServerContext (DbContextOptions<DocumentFlowServerContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<InternalDocument> InternalDocuments => Set<InternalDocument>();
        public DbSet<File> Files => Set<File>();
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Person> Persons => Set<Person>();
        public DbSet<Position> Positions => Set<Position>();
        public DbSet<State> States => Set<State>();
    }
}
