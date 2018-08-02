using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Chickenium.Dao
{

    /// <summary>
    /// Exchange設定
    /// </summary>
    public class MExchange
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public int CurrencyPair1 { get; set; }
        public int CurrencyPair2 { get; set; }
        public double Fee { get; set; }
        public int IsWebSocket { get; set; }
        public int Enabled { get; set; }
    }

    // DBコンテキスト
    public class MExchangeDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<MExchange> MExchange { get; set; }

        public MExchangeDbContext(DbContextOptions DbContextOptions) : base(DbContextOptions)
        {
            this.GetInfrastructure().GetService<ILoggerFactory>().AddProvider(new AppLoggerProvider());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // テーブルにマッピングする
            modelBuilder.Entity<MExchange>()
                .HasKey(c => new { c.Id });
        }
    }
}
