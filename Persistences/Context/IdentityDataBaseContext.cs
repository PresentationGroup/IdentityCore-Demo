using  Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace  Persistences.Context
{
    public class IdentityDataBaseContext : IdentityDbContext<User,Role,string>
    {
        public IdentityDataBaseContext(DbContextOptions<IdentityDataBaseContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityUser<string>>().ToTable("Users");
            builder.Entity<IdentityRole<string>>().ToTable("Roles");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");


            builder.Entity<IdentityUserLogin<string>>().HasKey(p => new { p.LoginProvider, p.ProviderKey });
            builder.Entity<IdentityUserRole<string>>().HasKey(p => new { p.UserId, p.RoleId });
            builder.Entity<IdentityUserToken<string>>().HasKey(p => new { p.UserId, p.LoginProvider, p.Name });
        }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    if (modelBuilder == null)
        //    {
        //        throw new ArgumentNullException("modelBuilder");
        //    }

        //    // Needed to ensure subclasses share the same table
        //    var user = modelBuilder.Entity<TUser>()
        //        .ToTable("AspNetUsers");
        //    user.HasMany(u => u.Roles).WithRequired().HasForeignKey(ur => ur.UserId);
        //    user.HasMany(u => u.Claims).WithRequired().HasForeignKey(uc => uc.UserId);
        //    user.HasMany(u => u.Logins).WithRequired().HasForeignKey(ul => ul.UserId);
        //    user.Property(u => u.UserName)
        //        .IsRequired()
        //        .HasMaxLength(256)
        //        .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("UserNameIndex") { IsUnique = true }));

        //    // CONSIDER: u.Email is Required if set on options?
        //    user.Property(u => u.Email).HasMaxLength(256);

        //    modelBuilder.Entity<TUserRole>()
        //        .HasKey(r => new { r.UserId, r.RoleId })
        //        .ToTable("AspNetUserRoles");

        //    modelBuilder.Entity<TUserLogin>()
        //        .HasKey(l => new { l.LoginProvider, l.ProviderKey, l.UserId })
        //        .ToTable("AspNetUserLogins");

        //    modelBuilder.Entity<TUserClaim>()
        //        .ToTable("AspNetUserClaims");

        //    var role = modelBuilder.Entity<TRole>()
        //        .ToTable("AspNetRoles");
        //    role.Property(r => r.Name)
        //        .IsRequired()
        //        .HasMaxLength(256)
        //        .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("RoleNameIndex") { IsUnique = true }));
        //    role.HasMany(r => r.Users).WithRequired().HasForeignKey(ur => ur.RoleId);
        //}

    }
}
