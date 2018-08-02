using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Chickenium.Dao
{

    /// <summary>
    /// MTechnicalParameter設定
    /// </summary>
    public class MTechnicalParameter
    {
        public int TechnicalId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public double Value { get; set; }
        public int Enabled { get; set; }
    }

    // DBコンテキスト
    public class MTechnicalParameterDbContext : DbContext
    {
        public DbSet<MTechnicalParameter> MTechnicalParameter { get; set; }

        public MTechnicalParameterDbContext(DbContextOptions DbContextOptions) : base(DbContextOptions)
        {
            this.GetInfrastructure().GetService<ILoggerFactory>().AddProvider(new AppLoggerProvider());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // テーブルにマッピングする
            modelBuilder.Entity<MTechnicalParameter>()
                .HasKey(c => new { c.TechnicalId, c.Id });
        }
    }
}
