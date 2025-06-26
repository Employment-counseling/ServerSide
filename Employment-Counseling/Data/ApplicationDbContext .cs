using Employment_Counseling.Entities;
using Microsoft.EntityFrameworkCore;

namespace Employment_Counseling.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Costumer> Costumers { get; set; }
        public DbSet<Counselor> Counselors { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<QuestionItem> QuestionItems { get; set; }
        public DbSet<Questionnaire> Questionnaires { get; set; }
        public DbSet<AnswerItem> AnswerItems { get; set; }
        public DbSet<UserAnswers> UserAnswers { get; set; }
        public DbSet<AuthToken> UsersTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Costumer>().ToTable("Costumers");
            modelBuilder.Entity<Counselor>().ToTable("Counselors");

            modelBuilder.Entity<QuestionItem>()
                .HasOne(q => q.Questionnaire)
                .WithMany(q => q.Questions)
                .HasForeignKey(q => q.QuestionnaireId);

            modelBuilder.Entity<AnswerItem>()
                .HasOne(a => a.UserAnswers)
                .WithMany(ua => ua.Answers)
                .HasForeignKey(a => a.UserAnswersId);

            modelBuilder.Entity<AnswerItem>()
                .HasOne(a => a.Question)
                .WithMany()
                .HasForeignKey(a => a.QuestionId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<UserAnswers>()
              .HasOne(ua => ua.Questionnaire)
              .WithMany()
              .HasForeignKey(ua => ua.QuestionnaireId)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserAnswers>()
               .HasOne(ua => ua.Costumer)
               .WithMany(c => c.UserAnswers)
               .HasForeignKey(ua => ua.CostumerId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Costumer>()
                .HasOne(c => c.Package)
                .WithMany()
                .HasForeignKey(c => c.PackageId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Package>()
                .HasMany(p => p.Questionnaires)
                .WithMany(q => q.Packages);

            modelBuilder.Entity<Counselor>()
                .HasMany(c => c.Packages)
                .WithMany(p => p.Counselors);

            modelBuilder.Entity<AuthToken>()
                .HasOne(t => t.User)
                .WithMany()
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AuthToken>()
                .HasIndex(t => t.Token)
                .IsUnique();

        }
    }
}
