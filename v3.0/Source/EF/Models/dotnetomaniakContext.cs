using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Kigg.LinqToSql.DomainObjects
{
    public partial class dotnetomaniakContext : DbContext
    {
        private readonly string _connectionString;

        public dotnetomaniakContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public dotnetomaniakContext(string connectionString, DbContextOptions<dotnetomaniakContext> options)
            : base(options)
        {
            _connectionString = connectionString;
        }

        public virtual DbSet<Achievement> Achievement { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<CommentSubscribtion> CommentSubscribtion { get; set; }
        public virtual DbSet<CommingEvent> CommingEvent { get; set; }
        public virtual DbSet<KnownSource> KnownSource { get; set; }
        public virtual DbSet<Recommendation> Recommendation { get; set; }
        public virtual DbSet<Story> Story { get; set; }
        public virtual DbSet<StoryComment> StoryComment { get; set; }
        public virtual DbSet<StoryMarkAsSpam> StoryMarkAsSpam { get; set; }
        public virtual DbSet<StoryTag> StoryTag { get; set; }
        public virtual DbSet<StoryView> StoryView { get; set; }
        public virtual DbSet<StoryVote> StoryVote { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserAchievement> UserAchievement { get; set; }
        public virtual DbSet<UserScore> UserScore { get; set; }
        public virtual DbSet<UserTag> UserTag { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Achievement>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("ntext");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(4000);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.UniqueName)
                    .IsRequired()
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<CommentSubscribtion>(entity =>
            {
                entity.HasKey(e => new { e.StoryId, e.UserId });

                entity.HasOne(d => d.Story)
                    .WithMany(p => p.CommentSubscribtions)
                    .HasForeignKey(d => d.StoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Story_CommentSubscribtion");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CommentSubscribtion)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("User_CommentSubscribtion");
            });

            modelBuilder.Entity<CommingEvent>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.EventLead)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EventLink)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EventName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EventPlace)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<KnownSource>(entity =>
            {
                entity.HasKey(e => e.Url);

                entity.Property(e => e.Url).ValueGeneratedNever();
            });

            modelBuilder.Entity<Recommendation>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.ImageLink)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ImageTitle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RecommendationLink)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RecommendationTitle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Story>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ApprovedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.HtmlDescription).IsRequired();

                entity.Property(e => e.IPAddress)
                    .IsRequired()
                    .HasColumnName("IPAddress")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.LastActivityAt).HasColumnType("datetime");

                entity.Property(e => e.LastProcessedAt).HasColumnType("datetime");

                entity.Property(e => e.PublishedAt).HasColumnType("datetime");

                entity.Property(e => e.TextDescription).IsRequired();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.UniqueName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(2048);

                entity.Property(e => e.UrlHash)
                    .IsRequired()
                    .HasMaxLength(24);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Story)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Category_Story");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Story)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("User_Story");
            });

            modelBuilder.Entity<StoryComment>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.HtmlBody).IsRequired();

                entity.Property(e => e.IPAddress)
                    .IsRequired()
                    .HasColumnName("IPAddress")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.TextBody).IsRequired();

                entity.HasOne(d => d.Story)
                    .WithMany(p => p.StoryComments)
                    .HasForeignKey(d => d.StoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Story_StoryComment");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.StoryComment)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("User_StoryComment");
            });

            modelBuilder.Entity<StoryMarkAsSpam>(entity =>
            {
                entity.HasKey(e => new { e.StoryId, e.UserId });

                entity.Property(e => e.IPAddress)
                    .IsRequired()
                    .HasColumnName("IPAddress")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Timestamp).HasColumnType("datetime");

                entity.HasOne(d => d.Story)
                    .WithMany(p => p.StoryMarkAsSpams)
                    .HasForeignKey(d => d.StoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Story_StoryMarkAsSpam");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.StoryMarkAsSpam)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("User_StoryMarkAsSpam");
            });

            modelBuilder.Entity<StoryTag>(entity =>
            {
                entity.HasKey(e => new { e.StoryId, e.TagId });

                entity.HasOne(d => d.Story)
                    .WithMany(p => p.StoryTags)
                    .HasForeignKey(d => d.StoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Story_StoryTag");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.StoryTags)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Tag_StoryTag");
            });

            modelBuilder.Entity<StoryView>(entity =>
            {
                entity.Property(e => e.IPAddress)
                    .IsRequired()
                    .HasColumnName("IPAddress")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Timestamp).HasColumnType("datetime");

                entity.HasOne(d => d.Story)
                    .WithMany(p => p.StoryViews)
                    .HasForeignKey(d => d.StoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Story_StoryView");
            });

            modelBuilder.Entity<StoryVote>(entity =>
            {
                entity.HasKey(e => new { e.StoryId, e.UserId });

                entity.Property(e => e.IPAddress)
                    .IsRequired()
                    .HasColumnName("IPAddress")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Timestamp).HasColumnType("datetime");

                entity.HasOne(d => d.Story)
                    .WithMany(p => p.StoryVotes)
                    .HasForeignKey(d => d.StoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Story_StoryVote");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.StoryVote)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("User_StoryVote");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.UniqueName)
                    .IsRequired()
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.FbId).HasMaxLength(256);

                entity.Property(e => e.LastActivityAt).HasColumnType("datetime");

                entity.Property(e => e.Password).HasMaxLength(64);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<UserAchievement>(entity =>
            {
                entity.HasKey(e => new { e.AchievementId, e.UserId });

                entity.Property(e => e.DateAchieved).HasColumnType("datetime");

                entity.HasOne(d => d.Achievement)
                    .WithMany(p => p.UserAchievement)
                    .HasForeignKey(d => d.AchievementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Achievement_UserAchievement");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserAchievements)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("User_UserAchievement");
            });

            modelBuilder.Entity<UserScore>(entity =>
            {
                entity.Property(e => e.Score).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Timestamp).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserScores)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("User_UserScore");
            });

            modelBuilder.Entity<UserTag>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.TagId });

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.UserTag)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Tag_UserTag");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserTags)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("User_UserTag");
            });
        }
    }
}
