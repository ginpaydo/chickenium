using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Chickenium.Dao
{

    /// <summary>
    /// MRecord設定
    /// </summary>
    public class MRecord
    {
        public int Id { get; set; }
        public int ExchangeId { get; set; }
        public int TechnicalId { get; set; }
        public int TimeScaleId { get; set; }
        public int Enabled { get; set; }
    }

    // DBコンテキスト
    public class MRecordDbContext : DbContext
    {
        public DbSet<MRecord> MRecord { get; set; }

        public MRecordDbContext(DbContextOptions DbContextOptions) : base(DbContextOptions)
        {
            this.GetInfrastructure().GetService<ILoggerFactory>().AddProvider(new AppLoggerProvider());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // テーブルにマッピングする
            modelBuilder.Entity<MRecord>()
                .HasKey(c => new { c.Id });
        }
    }
}
