using EventMaster.Models;
using Microsoft.EntityFrameworkCore;
namespace EventMaster.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options) { }


        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<SavedEvent> SavedEvents { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relationships
            modelBuilder.Entity<User>()
                .HasMany(u => u.OrganizedEvents)
                .WithOne(e => e.Organizer)
                .HasForeignKey(e => e.OrganizerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Event)
                .WithMany(e => e.Tickets)
                .HasForeignKey(t => t.EventId);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Participant)
                .WithMany(u => u.Tickets)
                .HasForeignKey(t => t.ParticipantId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SavedEvent>()
                .HasOne(se => se.Event)
                .WithMany(e => e.SavedEvents)
                .HasForeignKey(se => se.EventId);

            modelBuilder.Entity<SavedEvent>()
                .HasOne(se => se.Participant)
                .WithMany(u => u.SavedEvents)
                .HasForeignKey(se => se.ParticipantId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Notification>()
                .HasOne(n => n.Event)
                .WithMany(e => e.Notifications)
                .HasForeignKey(n => n.EventId);

            modelBuilder.Entity<Attachment>()
                .HasOne(a => a.Event)
                .WithMany(e => e.Attachments)
                .HasForeignKey(a => a.EventId);
        }

    }
}
