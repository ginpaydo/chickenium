using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Chickenium.Dao
{

    /// <summary>
    /// MAlgorithm設定
    /// </summary>
    public class MAlgorithm
    {
        public int Id { get; set; }
        public int ExchangeId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public int ClassId { get; set; }
        public int Enabled { get; set; }
    }

    // DBコンテキスト
    public class MAlgorithmDbContext : DbContext
    {
        public DbSet<MAlgorithm> MAlgorithm { get; set; }

        public MAlgorithmDbContext(DbContextOptions DbContextOptions) : base(DbContextOptions)
        {
            this.GetInfrastructure().GetService<ILoggerFactory>().AddProvider(new AppLoggerProvider());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // テーブルにマッピングする
            modelBuilder.Entity<MAlgorithm>()
                .HasKey(c => new { c.Id });
        }
    }
}
