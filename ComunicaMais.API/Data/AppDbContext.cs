using ComunicaMais.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ComunicaMais.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Device> Devices { get; set; } = null!;
        public DbSet<Message> Messages { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapeia tabela Devices
            modelBuilder.Entity<Device>(entity =>
            {
                entity.ToTable("DEVICES");  // nome da tabela em maiúsculas

                entity.HasKey(d => d.DeviceId);

                entity.Property(d => d.DeviceId)
                      .HasColumnName("DEVICEID")
                      .HasMaxLength(100)
                      .IsRequired();

                entity.Property(d => d.Name)
                      .HasColumnName("NAME")
                      .HasMaxLength(100)
                      .IsRequired();

                entity.Property(d => d.Status)
                      .HasColumnName("STATUS")
                      .HasMaxLength(50)
                      .IsRequired();

                entity.Property(d => d.LastSeen)
                      .HasColumnName("LASTSEEN");

                entity.HasMany(d => d.Messages)
                      .WithOne(m => m.Device)
                      .HasForeignKey(m => m.DeviceId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Mapeia tabela Messages
            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("MESSAGES");  // nome da tabela em maiúsculas

                entity.HasKey(m => m.MessageId);

                entity.Property(m => m.MessageId)
                      .HasColumnName("MESSAGEID")
                      .ValueGeneratedOnAdd();

                entity.Property(m => m.Sender)
                      .HasColumnName("SENDER")
                      .HasMaxLength(100)
                      .IsRequired();

                entity.Property(m => m.Content)
                      .HasColumnName("CONTENT")
                      .HasMaxLength(1000)
                      .IsRequired();

                entity.Property(m => m.Timestamp)
                      .HasColumnName("TIMESTAMP")
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(m => m.DeviceId)
                      .HasColumnName("DEVICEID")
                      .HasMaxLength(100)
                      .IsRequired();
            });
        }
    }
}
