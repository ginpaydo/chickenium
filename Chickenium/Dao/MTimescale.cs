using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Chickenium.Dao
{

    /// <summary>
    /// TimeScale設定
    /// </summary>
    public class MTimeScale
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public int SecondsValue { get; set; }
        public int Enabled { get; set; }
    }

    // DBコンテキスト
    public class MTimeScaleDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<MTimeScale> MTimeScale { get; set; }

        public MTimeScaleDbContext(DbContextOptions DbContextOptions) : base(DbContextOptions)
        {
            this.GetInfrastructure().GetService<ILoggerFactory>().AddProvider(new AppLoggerProvider());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // テーブルにマッピングする
            modelBuilder.Entity<MTimeScale>()
                .HasKey(c => new { c.Id });
        }
    }
}
