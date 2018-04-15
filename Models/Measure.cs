using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RecipeStorageAPI.Models
{
    public class Measure
    {
        public int ID { get; set; }
        public string Type { get; set; }

        
        [InverseProperty("Measure")]
        [JsonIgnore]
        public virtual ICollection<RecipeIngredients> RecipeIngredients { get; set; }
    }
}