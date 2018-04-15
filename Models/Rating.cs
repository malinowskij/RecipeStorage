using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeStorageAPI.Models
{
    public class Rating
    {
        public int ID { get; set; }
        public int Value { get; set; }

        public int RecipeID { get; set; }

        [JsonIgnore]
        public virtual Recipe Recipe { get; set; }
    }
}