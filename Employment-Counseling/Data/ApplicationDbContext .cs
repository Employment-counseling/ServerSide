using Employment_Counseling.Entities;
using Microsoft.EntityFrameworkCore;

namespace Employment_Counseling.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Questionnaire> Questionnaires { get; set; }
        public DbSet<PackageQuestionnaire> PackageQuestionnaires { get; set; }
        public DbSet<UserAnswer> UserAnswers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // קשר Many-to-Many בין חבילות לשאלונים
            modelBuilder.Entity<PackageQuestionnaire>()
                .HasKey(pq => new { pq.PackageId, pq.QuestionnaireId });

            modelBuilder.Entity<PackageQuestionnaire>()
                .HasOne(pq => pq.Package)
                .WithMany(p => p.PackageQuestionnaires)
                .HasForeignKey(pq => pq.PackageId);

            modelBuilder.Entity<PackageQuestionnaire>()
                .HasOne(pq => pq.Questionnaire)
                .WithMany()
                .HasForeignKey(pq => pq.QuestionnaireId);

            // קשר User -> Package
            modelBuilder.Entity<User>()
                .HasOne(u => u.Package)
                .WithMany(p => p.Users)
                .HasForeignKey(u => u.PackageId)
                .OnDelete(DeleteBehavior.Restrict);

            // קשר User -> UserAnswer -> Questionnaire
            modelBuilder.Entity<UserAnswer>()
                .HasOne(ua => ua.User)
                .WithMany(u => u.UserAnswers)
                .HasForeignKey(ua => ua.UserId);

            modelBuilder.Entity<UserAnswer>()
                .HasOne(ua => ua.Questionnaire)
                .WithMany()
                .HasForeignKey(ua => ua.QuestionnaireId);
        }
    }
}
