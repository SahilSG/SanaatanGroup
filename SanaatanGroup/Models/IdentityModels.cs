using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SanaatanGroup.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
            private set { }

        }
        //public string Email { get; set; }
        public string UserImage { get; set; }
        public string Gender { get; set; }
        public Nullable<DateTime> BirthDate { get; set; }
        public string LastIPAddress { get; set; }
        public Nullable<DateTime> LastLoginDate { get; set; }
        public Nullable<DateTime> LastActivityDate { get; set; }
        public string Address { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("SGroupData", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public System.Data.Entity.DbSet<SanaatanGroup.Models.JobSeeker>_JobSeeker { get; set; }
             
        public System.Data.Entity.DbSet<SanaatanGroup.Models.SanaatanResource> _SanaatanResource { get; set; }
        
        public System.Data.Entity.DbSet<SanaatanGroup.Models.MediaHeading> _MediaHeading { get; set; }
        public System.Data.Entity.DbSet<SanaatanGroup.Models.Media> _Media { get; set; }
        public System.Data.Entity.DbSet<SanaatanGroup.Models.Country> _Country { get; set; }
        public System.Data.Entity.DbSet<SanaatanGroup.Models.State> _State { get; set; }
        public System.Data.Entity.DbSet<SanaatanGroup.Models.City> _City { get; set; }
        public System.Data.Entity.DbSet<SanaatanGroup.Models.Event> _Event { get; set; }
    }
    public class AppRole : IdentityRole
    {
        public AppRole() : base() { }
        public AppRole(string name) : base(name) { }
    }
    public class RoleEditModel
    {

        public AppRole Role { get; set; }
        public IEnumerable<ApplicationUser> Members { get; set; }
        public IEnumerable<ApplicationUser> NonMembers { get; set; }
    }
    public class RoleModificationModel
    {
        [Required]
        public string RoleName { get; set; }
        public string[] IdsToAdd { get; set; }
        public string[] IdsToDelete { get; set; }
    }
}