using DevExpress.ExpressApp.EFCore.Updating;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.ExpressApp.Design;
using DevExpress.ExpressApp.EFCore.DesignTime;

namespace companyORM.Module.BusinessObjects;

// This code allows our Model Editor to get relevant EF Core metadata at design time.
// For details, please refer to https://supportcenter.devexpress.com/ticket/details/t933891.
public class companyORMContextInitializer : DbContextTypesInfoInitializerBase {
	protected override DbContext CreateDbContext() {
		var optionsBuilder = new DbContextOptionsBuilder<companyORMEFCoreDbContext>()
            .UseSqlServer(";")
            .UseChangeTrackingProxies()
            .UseObjectSpaceLinkProxies();
        return new companyORMEFCoreDbContext(optionsBuilder.Options);
	}
}
//This factory creates DbContext for design-time services. For example, it is required for database migration.
public class companyORMDesignTimeDbContextFactory : IDesignTimeDbContextFactory<companyORMEFCoreDbContext> {
	public companyORMEFCoreDbContext CreateDbContext(string[] args) {
		//throw new InvalidOperationException("Make sure that the database connection string and connection provider are correct. After that, uncomment the code below and remove this exception.");
		var optionsBuilder = new DbContextOptionsBuilder<companyORMEFCoreDbContext>();
		optionsBuilder.UseSqlServer("Integrated Security=SSPI;Data Source=(localdb)\\mssqllocaldb;Initial Catalog=companyORM");
        optionsBuilder.UseChangeTrackingProxies();
        optionsBuilder.UseObjectSpaceLinkProxies();
		return new companyORMEFCoreDbContext(optionsBuilder.Options);
	}
}
[TypesInfoInitializer(typeof(companyORMContextInitializer))]
public class companyORMEFCoreDbContext : DbContext {
	public companyORMEFCoreDbContext(DbContextOptions<companyORMEFCoreDbContext> options) : base(options) {
	}
	public DbSet<Employee> Employee { get; set; }
    public DbSet<Department> Department { get; set; }
    public DbSet<Project> Project { get; set; }
    public DbSet<Location> DepartmentLocation { get; set; }
    public DbSet<Dependent> Dependent { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Employee>()
          .HasKey(d => new { d.SSN });

        modelBuilder.Entity<Dependent>()
            .HasKey(d => new { d.EmployeeId, d.Name });

        modelBuilder.Entity<Location>()
           .HasKey(d => new { d.departamentLocation, d.DepartmentId });

        modelBuilder.Entity<Project>()
           .HasKey(d => new { d.ProjectNumber });


        modelBuilder.Entity<Employee>()
            .HasMany(c => c.SuperVisee)
            .WithOne(c => c.SuperVisor)
            .HasForeignKey(c => c.SuperVisorId);

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.WorksForDepartment)
            .WithMany(d => d.Employees)
            .HasForeignKey(e => e.DepartmentId) 
            .IsRequired(false);

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Manages)
            .WithOne(d => d.Manager)
            .HasForeignKey<Employee>(e => e.ManagesDepartmentId) 
            .IsRequired(false);

        modelBuilder.Entity<Department>()
            .HasKey(d => new { d.DepartmentNumber });

        modelBuilder.Entity<Department>()
            .HasMany(d => d.Employees)
            .WithOne(e => e.WorksForDepartment)
            .HasForeignKey(e => e.DepartmentId);

        modelBuilder.Entity<Employee>()
            .HasMany(e => e.Dependees)
            .WithOne(e => e.Employee)
            .HasForeignKey(d => d.EmployeeId);

        modelBuilder.Entity<Dependent>()
            .Property(d => d.Name)
            .IsRequired();

        base.OnModelCreating(modelBuilder);
    }
}
