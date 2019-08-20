using InCoqnito.Kalender.Data.KalenderEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InCoqnito.Kalender.Data
{
    public partial class KalenderDBContext : DbContext
    {
        public KalenderDBContext()
        {
        }

        public KalenderDBContext(DbContextOptions<KalenderDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EmailTemplate> EmailTemplate { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeInvitationMap> EmployeeInvitationMap { get; set; }
        public virtual DbSet<Invitation> Invitation { get; set; }
        public virtual DbSet<Role> Role { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<EmailTemplate>(entity =>
            {
                entity.Property(e => e.Template)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Subject)
                   .IsRequired()
                   .HasMaxLength(500)
                   .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId);

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.EmpEmailId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Role");
            });

            modelBuilder.Entity<EmployeeInvitationMap>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Comments)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.InvitationId).HasColumnName("InvitationID");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.EmployeeInvitationMap)
                    .HasForeignKey(d => d.EmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeInvitationMap_Employee");

                entity.HasOne(d => d.Invitation)
                    .WithMany(p => p.EmployeeInvitationMap)
                    .HasForeignKey(d => d.InvitationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeInvitationMap_Invitation");
            });

            modelBuilder.Entity<Invitation>(entity =>
            {
                entity.Property(e => e.InvitationId).HasColumnName("InvitationID");

                entity.Property(e => e.CreatedOn).HasColumnType("date");

                entity.Property(e => e.InvDate).HasColumnType("date");

                entity.Property(e => e.InvitationDescription)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateOn).HasColumnType("date");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Invitation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invitation_Employee");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
