using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RecipeStorageAPI.Models
{
    public class Recipe
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Nazwa")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Nazwa przepisu nie może być dłuższa niż 50 znaków i krótsza niż 5")]
        public string Name { get; set; }

        [Display(Name = "Opis")]
        [Required]
        [StringLength(10000, MinimumLength = 5, ErrorMessage = "Opis przepisu nie może być dłuższy niż 10000 znaków i krótsza niż 5")]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedDate { get; set; }

        [Required]
        public int PreparationTimeInMinutes { get; set; }

        public string ApplicationUserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        public int CookTimeInMinutes { get; set; }

        public int RecipeCategoryID { get; set; }

        public virtual RecipeCategory RecipeCategory { get; set; }

        [InverseProperty("Recipe")]
        public virtual ICollection<RecipeIngredients> RecipeIngredients { get; set; }

        public virtual ICollection<RecipeStep> RecipeSteps { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        [JsonIgnore]
        public virtual ICollection<Rating> Ratings { get; set; }

        [JsonIgnore]
        public virtual ICollection<Comment> Comments { get; set; }
    }
}