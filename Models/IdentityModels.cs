using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Runtime.Serialization;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json;

namespace RecipeStorageAPI.Models
{
    // Możesz dodać dane profilu dla użytkownika, dodając więcej właściwości do klasy ApplicationUser. Odwiedź stronę https://go.microsoft.com/fwlink/?LinkID=317594, aby dowiedzieć się więcej.
    [DataContract]
    public class ApplicationUser : IdentityUser
    {
        [DataMember]
        [Required]
        public string FirstName { get; set; }

        [DataMember]
        [Required]
        public string LastName { get; set; }
        
        [DataMember]
        public override string UserName { get => base.UserName; set => base.UserName = value; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Element authenticationType musi pasować do elementu zdefiniowanego w elemencie CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Dodaj tutaj niestandardowe oświadczenia użytkownika
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeCategory> RecipeCategories { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Measure> Measures { get; set; }
        public DbSet<Image> RecipeImages { get; set; }
        public DbSet<RecipeStep> RecipeSteps { get; set; }
        public DbSet<RecipeIngredients> RecipeIngredients { get; set; }

        public System.Data.Entity.DbSet<RecipeStorageAPI.Models.Comment> Comments { get; set; }
    }
}