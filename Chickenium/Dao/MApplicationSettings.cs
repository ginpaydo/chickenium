using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Chickenium.Dao
{

    /// <summary>
    /// アプリケーション設定
    /// </summary>
    public class MApplicationSettings
    {
        public int ExchangeId { get; set; }
        public int Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Discription { get; set; }
    }

    // DBコンテキスト
    public class MApplicationSettingsDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<MApplicationSettings> MApplicationSettings { get; set; }

        public MApplicationSettingsDbContext(DbContextOptions DbContextOptions) : base(DbContextOptions)
        {
            this.GetInfrastructure().GetService<ILoggerFactory>().AddProvider(new AppLoggerProvider());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // テーブルにマッピングする
            //modelBuilder.Entity<ApplicationSettings>().ToTable("ApplicationSettings");
            modelBuilder.Entity<MApplicationSettings>()
                .HasKey(c => new { c.ExchangeId, c.Id });
        }
    }
}
