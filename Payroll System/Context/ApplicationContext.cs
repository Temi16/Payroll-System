using System;
using Microsoft.EntityFrameworkCore;
using Payroll_System.Auth.Service;
using Payroll_System.Entities;
using Payroll_System.Identity;


namespace Payroll_System.Context
{
    public class ApplicationContext : DbContext
    {
        private readonly IIdentityService _identityService;
        
        public ApplicationContext(DbContextOptions<ApplicationContext> options, IIdentityService identityService) : base(options)
        {
            _identityService = identityService;
;       }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne<Admin>(b => b.Admin)
                .WithOne(d => d.User)
                .HasForeignKey<Admin>(d => d.UserId);

            modelBuilder.Entity<User>()
               .HasOne<Employee>(b => b.Employee)
               .WithOne(d => d.User)
               .HasForeignKey<Employee>(d => d.UserId);
            Guid userId = Guid.NewGuid();
            Guid adminId = Guid.NewGuid();
            string salt = _identityService.GenerateSalt();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = userId,
                FirstName = "Roqeeb",
                LastName = "Temidayo",
                Email = "raufroqeeb123@gmail.com",
                IsDeleted = false,
                IsEmailConfirmed = true

            }) ; 
            modelBuilder.Entity<Admin>().HasData(new Admin
            {
                Id = adminId,
                UserId = userId,
                FirstName = "Roqeeb",
                LastName = "Temidayo",
                Email = "raufroqeeb123@gmail.com",
                Age = 20,
                IsDeleted = false,
                
            });
            Guid roleId = Guid.NewGuid();
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = roleId,
                Name = "Admin",
                IsDeleted = false
            });
            Guid userRoleId = Guid.NewGuid();
            modelBuilder.Entity<UserRole>().HasData(new UserRole
            {
                Id = userRoleId,
                UserId = userId,
                RoleId = roleId,
                IsDeleted = false
            });
            Guid roleId2 = Guid.NewGuid();
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = roleId2,
                Name = "Employee",
                IsDeleted = false
            });
        }

        public DbSet<CadreLevel> CadreLevels { get; set; }
        public DbSet<Earnings> Earnings { get; set; }
        public DbSet<Deductions> Deductions { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }  
      
    }
}
