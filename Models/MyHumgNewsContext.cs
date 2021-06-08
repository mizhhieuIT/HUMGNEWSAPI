using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HumgNewsAPI.Models
{
    public partial class MyHumgNewsContext : DbContext
    {
        public MyHumgNewsContext()
        {
        }

        public MyHumgNewsContext(DbContextOptions<MyHumgNewsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Attachment> Attachments { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<NewRecipient> NewRecipients { get; set; }
        public virtual DbSet<News> News { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server='DESKTOP-GB8U56B';Database='MyHumgNews';Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Vietnamese_CI_AS");

            modelBuilder.Entity<Attachment>(entity =>
            {
                entity.ToTable("Attachment");

                entity.Property(e => e.AttachmentId).HasColumnName("AttachmentID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedTime).HasColumnType("smalldatetime");

                entity.Property(e => e.DisplayName).HasMaxLength(300);

                entity.Property(e => e.ExpiredTime).HasColumnType("smalldatetime");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedTime).HasColumnType("smalldatetime");

                entity.Property(e => e.NewsId).HasColumnName("NewsID");

                entity.Property(e => e.Status).HasMaxLength(20);

                entity.HasOne(d => d.News)
                    .WithMany(p => p.Attachments)
                    .HasForeignKey(d => d.NewsId)
                    .HasConstraintName("FK_Attachment_News1");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CategoryName).HasMaxLength(100);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedTime).HasColumnType("smalldatetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedTime).HasColumnType("smalldatetime");

                entity.Property(e => e.Status).HasMaxLength(20);
            });

            modelBuilder.Entity<NewRecipient>(entity =>
            {
                entity.ToTable("NewRecipient");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ImportantLevel).HasMaxLength(20);

                entity.Property(e => e.MarkedAs).HasMaxLength(20);

                entity.Property(e => e.NewsId).HasColumnName("NewsID");

                entity.Property(e => e.ReadTime).HasColumnType("smalldatetime");

                entity.Property(e => e.ReceivedTime).HasColumnType("smalldatetime");

                entity.Property(e => e.RecipientCode).HasMaxLength(20);

                entity.Property(e => e.RecipientType).HasMaxLength(20);

                entity.Property(e => e.SelectedGroupCode).HasMaxLength(20);

                entity.Property(e => e.SelectedGroupType).HasMaxLength(20);

                entity.Property(e => e.Status).HasMaxLength(20);

                entity.HasOne(d => d.News)
                    .WithMany(p => p.NewRecipients)
                    .HasForeignKey(d => d.NewsId)
                    .HasConstraintName("FK_NewRecipient_News1");
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.Property(e => e.NewsId).HasColumnName("NewsID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Content).HasColumnType("ntext");

                entity.Property(e => e.CreateBy).HasMaxLength(50);

                entity.Property(e => e.CreatedTime).HasColumnType("smalldatetime");

                entity.Property(e => e.ExpiredTime).HasColumnType("smalldatetime");

                entity.Property(e => e.Image).HasMaxLength(300);

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedTime).HasColumnType("smalldatetime");

                entity.Property(e => e.PublishedBy).HasMaxLength(50);

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_News_Category");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
