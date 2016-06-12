using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Karma.Services.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Badge> Badges { get; set; }

        public virtual ICollection<Quest> OwnedQuests { get; set; }

        public virtual ICollection<Quest> RequestedQuests { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Badge> Badges { get; set; }

        public DbSet<Quest> Quests { get; set; }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUser>().ToTable("Users");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");

            // User
            modelBuilder.Entity<User>().Property(x => x.Name).IsRequired();

            // Quest 
            modelBuilder.Entity<Quest>().ToTable("Quests");
            modelBuilder.Entity<Quest>().Property(t => t.Title).IsRequired();
            modelBuilder.Entity<Quest>().HasRequired(t => t.Creator).WithMany(t => t.OwnedQuests).HasForeignKey(x => x.CreatorId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Quest>().HasRequired(t => t.Actor).WithMany(t => t.RequestedQuests).HasForeignKey(x => x.ActorId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Quest>().Property(t => t.DueDate).IsRequired();

            // Badge
            modelBuilder.Entity<Badge>().ToTable("Badges");
            modelBuilder.Entity<Badge>().Property(t => t.Title).IsRequired();
            modelBuilder.Entity<Badge>().HasMany(t => t.Users).WithMany(x => x.Badges); // many to many
        }
    }
}