using Microsoft.EntityFrameworkCore;
using School.System.Documents;
using School.System.Roles;
using School.System.Tasks;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace School.System.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class SystemDbContext :
    AbpDbContext<SystemDbContext>,
    ITenantManagementDbContext,
    IIdentityDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */


    #region Entities from the modules

    /* Notice: We only implemented IIdentityProDbContext and ISaasDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityProDbContext and ISaasDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    // Identity
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Guardian> Guardians { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<StudentTask> StudentTasks  { get; set; }
    public DbSet<TaskDefinition> TaskDefinitions { get; set; }
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }
    public DbSet<IdentitySession> Sessions { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public SystemDbContext(DbContextOptions<SystemDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureFeatureManagement();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureTenantManagement();
        builder.ConfigureBlobStoring();
        
        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(SystemConsts.DbTablePrefix + "YourEntities", SystemConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
        builder.Entity<Teacher>(b=>
        {
            b.ToTable(SystemConsts.DbTablePrefix + "Teachers", SystemConsts.DbSchema);
       
        b.ConfigureByConvention();
        b.Property(x => x.TeacherName).IsRequired().HasMaxLength(RoleConsts.MaxNameLength);
        b.HasIndex(x => x.TeacherName);
        });
        builder.Entity<Student>(b=>
        {
            b.ToTable(SystemConsts.DbTablePrefix + "Students", SystemConsts.DbSchema);
       
            b.ConfigureByConvention();
            b.Property(x => x.StudentName).IsRequired().HasMaxLength(RoleConsts.MaxNameLength);
            b.HasIndex(x => x.StudentName);
            b.HasOne<Guardian>().WithMany().HasForeignKey(x => x.GuardianId).IsRequired();
            
        });
        builder.Entity<Guardian>(b=>
        {
            b.ToTable(SystemConsts.DbTablePrefix + "Guardians", SystemConsts.DbSchema);
       
            b.ConfigureByConvention();
            b.Property(x => x.GuardianName).IsRequired().HasMaxLength(RoleConsts.MaxNameLength);
            b.HasIndex(x => x.GuardianName);
            b.HasMany<Student>().WithOne().HasForeignKey(x=>x.GuardianId).IsRequired();
        });
        builder.Entity<Document>(b =>
        {
            b.ToTable(SystemConsts.DbTablePrefix + "Document", SystemConsts.DbSchema);
            b.ConfigureByConvention();
        });
        builder.Entity<TaskDefinition>(b =>
        {
            b.ToTable(SystemConsts.DbTablePrefix + "TaskDefinitions", SystemConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Title).IsRequired().HasMaxLength(100);
            b.HasIndex(x => x.Title);
            b.HasOne<Teacher>()
                .WithMany()
                .HasForeignKey(x => x.TeacherId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        });
        builder.Entity<StudentTask>(b =>
        {
            b.ToTable(SystemConsts.DbTablePrefix + "StudentTasks", SystemConsts.DbSchema);
            b.ConfigureByConvention();
            // TaskDefinition ilişkisi (bir görev, birçok öğrenci görevi olabilir)
     
            b.HasOne<TaskDefinition>()
                .WithMany() 
                .HasForeignKey(x => x.TaskDefinitionId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction); 

            // Student ilişkisi (bir öğrenci, birçok görev alabilir)
            b.HasOne<Student>()
                .WithMany()
                .HasForeignKey(x => x.StudentId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction); 

            // Teacher ilişkisi (görevi atayan öğretmen)
            b.HasOne<Teacher>()
                .WithMany() 
                .HasForeignKey(x => x.AssignedTeacherId)
                .OnDelete(DeleteBehavior.NoAction); 
        });
    }
}
