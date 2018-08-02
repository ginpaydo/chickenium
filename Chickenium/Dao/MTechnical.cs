using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Chickenium.Dao
{

    /// <summary>
    /// MTechnical設定
    /// </summary>
    public class MTechnical
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public int ClassId { get; set; }
        public int RenderId { get; set; }
        public int Initialize { get; set; }
        public int Enabled { get; set; }
    }

    // DBコンテキスト
    public class MTechnicalDbContext : DbContext
    {
        public DbSet<MTechnical> MTechnical { get; set; }

        public MTechnicalDbContext(DbContextOptions DbContextOptions) : base(DbContextOptions)
        {
            this.GetInfrastructure().GetService<ILoggerFactory>().AddProvider(new AppLoggerProvider());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // テーブルにマッピングする
            modelBuilder.Entity<MTechnical>()
                .HasKey(c => new { c.Id });
        }
    }
}
