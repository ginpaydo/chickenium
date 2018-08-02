using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Chickenium.Dao
{

    /// <summary>
    /// MAlgorithmParameter設定
    /// </summary>
    public class MAlgorithmParameter
    {
        public int AlgorithmId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public double Value { get; set; }
        public int Enabled { get; set; }
    }

    // DBコンテキスト
    public class MAlgorithmParameterDbContext : DbContext
    {
        public DbSet<MAlgorithmParameter> MAlgorithmParameter { get; set; }

        public MAlgorithmParameterDbContext(DbContextOptions DbContextOptions) : base(DbContextOptions)
        {
            this.GetInfrastructure().GetService<ILoggerFactory>().AddProvider(new AppLoggerProvider());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // テーブルにマッピングする
            modelBuilder.Entity<MAlgorithmParameter>()
                .HasKey(c => new { c.AlgorithmId, c.Id });
        }
    }
}
