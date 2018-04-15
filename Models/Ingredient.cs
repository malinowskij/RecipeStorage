using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RecipeStorageAPI.Models
{
    public class Ingredient
    {
        public int ID { get; set; }
        
        [Required]
        public string Name { get; set; }

        [InverseProperty("Ingredient")]
        [JsonIgnore]    
        public virtual ICollection<RecipeIngredients> RecipeIngredients { get; set; }
    }
}