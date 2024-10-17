using Microsoft.EntityFrameworkCore;
using FormApi.Entities;

namespace FormApi
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<PhoneRecord> PhoneRecords { get; set; }
    }
}
