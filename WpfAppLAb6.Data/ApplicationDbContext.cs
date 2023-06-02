using Microsoft.EntityFrameworkCore;
using WpfApplab6.Objects;

namespace WpfAppLAb6.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<OrganizationType> OrganizationTypes { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<CaptureAct> CaptureActs { get; set; }
        public DbSet<AnimalCapture> AnimalCaptures { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany()
                .HasForeignKey(u => u.RoleId);
            modelBuilder.Entity<User>()
                .HasOne(u => u.Organization)
                .WithMany()
                .HasForeignKey(u => u.OrganizationId);
            modelBuilder.Entity<Organization>()
                .HasOne(u => u.OrganizationType)
                .WithMany()
                .HasForeignKey(u => u.OrganizationTypeId); 
            modelBuilder.Entity<Organization>()
                .HasOne(u => u.City)
                .WithMany()
                .HasForeignKey(u => u.CityId);
            modelBuilder.Entity<Claim>()
                .HasOne(u => u.City)
                .WithMany()
                .HasForeignKey(u => u.CityId);
            modelBuilder.Entity<Contract>()
                .HasOne(u => u.Customer)
                .WithMany()
                .HasForeignKey(u => u.CustomerId);
            modelBuilder.Entity<Contract>()
                .HasOne(u => u.Executor)
                .WithMany()
                .HasForeignKey(u => u.ExecutorId);
            modelBuilder.Entity<CaptureAct>()
                .HasOne(u => u.Claim)
                .WithMany()
                .HasForeignKey(u => u.ClaimId);
            modelBuilder.Entity<CaptureAct>()
                .HasOne(u => u.Organization)
                .WithMany()
                .HasForeignKey(u => u.OrganizationId);
            modelBuilder.Entity<CaptureAct>()
                .HasOne(u => u.Contract)
                .WithMany()
                .HasForeignKey(u => u.ContractId);
            modelBuilder.Entity<AnimalCapture>()
                .HasOne(u => u.CaptureAct)
                .WithMany()
                .HasForeignKey(u => u.CaptureActId);
            modelBuilder.Entity<AnimalCapture>()
                .HasOne(u => u.City)
                .WithMany()
                .HasForeignKey(u => u.CityId);
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=lab6testdb;Username=postgres;Password=root;"
            );
        }
    }
}