using Desafio_DevWebCloudAWSPractitioner.Infrastructure.DBContext.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Desafio_DevWebCloudAWSPractitioner.Infrastructure.DBContext
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        { }
        public DbSet<StudentEntity> Students { get; set; }
        public DbSet<SchoolInfosEntity> SchoolInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
