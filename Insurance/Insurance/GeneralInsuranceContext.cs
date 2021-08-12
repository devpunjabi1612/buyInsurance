using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Insurance.Insurance
{
    public partial class GeneralInsuranceContext : DbContext
    {
        public GeneralInsuranceContext()
        {
        }

        public GeneralInsuranceContext(DbContextOptions<GeneralInsuranceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Claim> Claims { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<InsurancePolicy> InsurancePolicies { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<TravelInsurance> TravelInsurances { get; set; }
        public virtual DbSet<TravelModel> TravelModels { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<VehicleCustomer> VehicleCustomers { get; set; }
        public virtual DbSet<VehicleInsurance> VehicleInsurances { get; set; }
        public virtual DbSet<VehicleModel> VehicleModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-27G3JVJ;Database=GeneralInsurance;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.Property(e => e.AdminId).HasColumnName("Admin_Id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Name_");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("Password_");
            });

            modelBuilder.Entity<Claim>(entity =>
            {
                entity.ToTable("Claim");

                entity.Property(e => e.ClaimId).HasColumnName("Claim_Id");

                entity.Property(e => e.AmountInsured)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Amount_Insured");

                entity.Property(e => e.ApprovalStatus)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Approval_Status");

                entity.Property(e => e.Contact)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfSubmission)
                    .HasColumnType("date")
                    .HasColumnName("Date_Of_Submission");

                entity.Property(e => e.InsuranceId).HasColumnName("Insurance_Id");

                entity.Property(e => e.ReasonToClaim)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Reason_To_Claim");

                entity.HasOne(d => d.ContactNavigation)
                    .WithMany(p => p.Claims)
                    .HasForeignKey(d => d.Contact)
                    .HasConstraintName("fk_ccontact");

                entity.HasOne(d => d.Insurance)
                    .WithMany(p => p.Claims)
                    .HasForeignKey(d => d.InsuranceId)
                    .HasConstraintName("fk_cinsurance_id");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Contact)
                    .HasName("pk_contact");

                entity.ToTable("Customer");

                entity.HasIndex(e => e.Email, "u_email")
                    .IsUnique();

                entity.Property(e => e.Contact)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Address_");

                entity.Property(e => e.Dob).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("First_Name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Last_Name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("Password_");
            });

            modelBuilder.Entity<InsurancePolicy>(entity =>
            {
                entity.HasKey(e => e.InsuranceId)
                    .HasName("pk_insurance_id");

                entity.ToTable("Insurance_Policy");

                entity.Property(e => e.InsuranceId).HasColumnName("Insurance_Id");

                entity.Property(e => e.Contact)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.IssueDate)
                    .HasColumnType("date")
                    .HasColumnName("Issue_Date");

                entity.Property(e => e.PolicyType)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Policy_Type");

                entity.HasOne(d => d.ContactNavigation)
                    .WithMany(p => p.InsurancePolicies)
                    .HasForeignKey(d => d.Contact)
                    .HasConstraintName("fk_ip_contact");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.PaymentId).HasColumnName("Payment_Id");

                entity.Property(e => e.Contact)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.InsuranceId).HasColumnName("Insurance_Id");

                entity.Property(e => e.PremiumAmount)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Premium_Amount");

                entity.HasOne(d => d.ContactNavigation)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.Contact)
                    .HasConstraintName("fk_pcontact");

                entity.HasOne(d => d.Insurance)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.InsuranceId)
                    .HasConstraintName("fk_pinsurance_id");
            });

            modelBuilder.Entity<TravelInsurance>(entity =>
            {
                entity.HasKey(e => e.TravelPolicyNumber)
                    .HasName("pk_travel_policy_number");

                entity.ToTable("Travel_Insurance");

                entity.Property(e => e.TravelPolicyNumber)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("Travel_Policy_Number");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("End_Date");

                entity.Property(e => e.InsuranceId).HasColumnName("Insurance_Id");

                entity.Property(e => e.PolicyType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Policy_Type");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("Start_Date_");

                entity.Property(e => e.TravelMode)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("Travel_Mode");

                entity.Property(e => e.TravelType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Travel_Type");

                entity.HasOne(d => d.Insurance)
                    .WithMany(p => p.TravelInsurances)
                    .HasForeignKey(d => d.InsuranceId)
                    .HasConstraintName("fk_t_insurance_id");
            });

            modelBuilder.Entity<TravelModel>(entity =>
            {
                entity.HasKey(e => e.TravelId)
                    .HasName("pk_t_model_id");

                entity.ToTable("Travel_Model");

                entity.Property(e => e.TravelId).HasColumnName("Travel_Id");

                entity.Property(e => e.LengthOfStay).HasColumnName("Length_Of_Stay");

                entity.Property(e => e.PricePerPerson)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Price_Per_Person");

                entity.Property(e => e.TravelType)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Travel_Type");
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasKey(e => e.RegistrationNumber)
                    .HasName("pk_registration_number");

                entity.ToTable("Vehicle");

                entity.Property(e => e.RegistrationNumber)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Registration_Number");

                entity.Property(e => e.ChassisNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Chassis_Number");

                entity.Property(e => e.DrivingLicense)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("Driving_License");

                entity.Property(e => e.EngineNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Engine_Number");

                entity.Property(e => e.Manufacturer)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PurchasedDate)
                    .HasColumnType("date")
                    .HasColumnName("Purchased_Date");

                entity.Property(e => e.VehicleType)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("Vehicle_Type");
            });

            modelBuilder.Entity<VehicleCustomer>(entity =>
            {
                entity.HasKey(e => e.VCid)
                    .HasName("pk_vcid");

                entity.ToTable("Vehicle_Customer");

                entity.Property(e => e.VCid).HasColumnName("V_Cid");

                entity.Property(e => e.Contact)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RegistrationNumber)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Registration_Number");

                entity.HasOne(d => d.ContactNavigation)
                    .WithMany(p => p.VehicleCustomers)
                    .HasForeignKey(d => d.Contact)
                    .HasConstraintName("fk_vc_contact");

                entity.HasOne(d => d.RegistrationNumberNavigation)
                    .WithMany(p => p.VehicleCustomers)
                    .HasForeignKey(d => d.RegistrationNumber)
                    .HasConstraintName("fk_registration_number");
            });

            modelBuilder.Entity<VehicleInsurance>(entity =>
            {
                entity.HasKey(e => e.VehiclePolicyNumber)
                    .HasName("pk_vehicle_policy_number");

                entity.ToTable("Vehicle_Insurance");

                entity.Property(e => e.VehiclePolicyNumber)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("Vehicle_Policy_Number");

                entity.Property(e => e.InsuranceId).HasColumnName("Insurance_Id");

                entity.Property(e => e.PlanType)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.VehicleType)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("Vehicle_type");

                entity.HasOne(d => d.Insurance)
                    .WithMany(p => p.VehicleInsurances)
                    .HasForeignKey(d => d.InsuranceId)
                    .HasConstraintName("fk_v_insurance_id");
            });

            modelBuilder.Entity<VehicleModel>(entity =>
            {
                entity.HasKey(e => e.ModelId)
                    .HasName("pk_v_model_id");

                entity.ToTable("Vehicle_Model");

                entity.Property(e => e.ModelId).HasColumnName("Model_Id");

                entity.Property(e => e.ModelName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Model_Name");

                entity.Property(e => e.ModelType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Model_Type");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
