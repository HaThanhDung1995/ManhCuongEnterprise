namespace WebEnter.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
        }

        public virtual DbSet<Arranx> Arranges { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Master> Masters { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Turtor> Turtors { get; set; }
        public virtual DbSet<MasterRole> MasterRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Feedback>()
                .Property(e => e.Feedback1)
                .IsUnicode(false);

            modelBuilder.Entity<Master>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Master>()
                .Property(e => e.Pass)
                .IsUnicode(false);

            modelBuilder.Entity<Report>()
                .Property(e => e.Meeting)
                .IsUnicode(false);

            modelBuilder.Entity<Report>()
                .Property(e => e.Documents)
                .IsUnicode(false);

            modelBuilder.Entity<Report>()
                .Property(e => e.Comments)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.RoleName)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Pass)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Fullname)
                .IsUnicode(false);

            modelBuilder.Entity<Turtor>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Turtor>()
                .Property(e => e.Pass)
                .IsUnicode(false);

            modelBuilder.Entity<Turtor>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Turtor>()
                .Property(e => e.Fullname)
                .IsUnicode(false);

            modelBuilder.Entity<Turtor>()
                .HasMany(e => e.Arranges)
                .WithOptional(e => e.Turtor)
                .HasForeignKey(e => e.TutorId);

            modelBuilder.Entity<Turtor>()
                .HasMany(e => e.Feedbacks)
                .WithOptional(e => e.Turtor)
                .HasForeignKey(e => e.TutorId);

            modelBuilder.Entity<Turtor>()
                .HasMany(e => e.Reports)
                .WithOptional(e => e.Turtor)
                .HasForeignKey(e => e.TutorId);
        }
    }
}
