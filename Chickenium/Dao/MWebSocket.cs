using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Chickenium.Dao
{

    /// <summary>
    /// WebSocket設定
    /// </summary>
    public class MWebSocket
    {
        public int ExchangeId { get; set; }
        public int UseId { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string Value { get; set; }
        public string Discription { get; set; }
        public int Enabled { get; set; }
    }

    // DBコンテキスト
    public class MWebSocketDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<MWebSocket> MWebSocket { get; set; }

        public MWebSocketDbContext(DbContextOptions DbContextOptions) : base(DbContextOptions)
        {
            this.GetInfrastructure().GetService<ILoggerFactory>().AddProvider(new AppLoggerProvider());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // テーブルにマッピングする
            //modelBuilder.Entity<MWebSocket>().ToTable("MWebSocket");
            modelBuilder.Entity<MWebSocket>()
                .HasKey(c => new { c.ExchangeId, c.UseId });
        }
    }
}
