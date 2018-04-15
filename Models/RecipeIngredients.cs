using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RecipeStorageAPI.Models
{
    public class RecipeIngredients
    {
        public int ID { get; set; }
        public int RecipeID { get; set; }
        public int IngredientID { get; set; }
        public int MeasureID { get; set; }

        [Required]
        public int Amount { get; set; }

        [ForeignKey("RecipeID")]
        [InverseProperty("RecipeIngredients")]
        public virtual Recipe Recipe { get; set; }

        [ForeignKey("IngredientID")]
        [InverseProperty("RecipeIngredients")]
        public virtual Ingredient Ingredient { get; set; }

        [ForeignKey("MeasureID")]
        [InverseProperty("RecipeIngredients")]
        public virtual Measure Measure { get; set; }
    }
}