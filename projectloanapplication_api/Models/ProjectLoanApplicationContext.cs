using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace projectloanapplication_api.Models
{
    public partial class ProjectLoanApplicationContext : DbContext
    {
        public ProjectLoanApplicationContext()
        {
        }

        public ProjectLoanApplicationContext(DbContextOptions<ProjectLoanApplicationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblLoanapplication> TblLoanapplications { get; set; }
        public virtual DbSet<TblMasterJob> TblMasterJobs { get; set; }
        public virtual DbSet<TblMasterLoantype> TblMasterLoantypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server = JBMAC073\\SQLEXPRESS; initial catalog = ProjectLoanApplication;integrated security = true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TblLoanapplication>(entity =>
            {
                entity.HasKey(e => e.LoanApplicationNumber)
                    .HasName("PK__tbl_loan__CF773C38F9D18B3D");

                entity.ToTable("tbl_loanapplication");

                entity.Property(e => e.LoanApplicationNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("loan_application_number");

                entity.Property(e => e.AadharNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("aadhar_number");

                entity.Property(e => e.AlternateNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("alternate_number");

                entity.Property(e => e.AnnualIncome).HasColumnName("annual_income");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("created_date");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("date_of_birth");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("email_id");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("full_name");

                entity.Property(e => e.InterestOnYear).HasColumnName("interest_on_year");

                entity.Property(e => e.JobType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("job_type");

                entity.Property(e => e.LoanAmount).HasColumnName("loan_amount");

                entity.Property(e => e.LoanType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("loan_type");

                entity.Property(e => e.PanNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("pan_number");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("phone_number");

                entity.Property(e => e.RecordStatus).HasColumnName("record_status");

                entity.Property(e => e.UserAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("user_address");
            });

            modelBuilder.Entity<TblMasterJob>(entity =>
            {
                entity.HasKey(e => e.JobId)
                    .HasName("PK__tbl_mast__6E32B6A5C0C3218D");

                entity.ToTable("tbl_master_jobs");

                entity.Property(e => e.JobId).HasColumnName("job_id");

                entity.Property(e => e.JobName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("job_name");
            });

            modelBuilder.Entity<TblMasterLoantype>(entity =>
            {
                entity.HasKey(e => e.LoanTypeId)
                    .HasName("PK__tbl_mast__9B1A1721F291240E");

                entity.ToTable("tbl_master_loantypes");

                entity.Property(e => e.LoanTypeId).HasColumnName("loan_type_id");

                entity.Property(e => e.LoanName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("loan_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
