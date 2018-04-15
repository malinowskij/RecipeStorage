using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeStorageAPI.Models
{
    public class RecipeStep
    {
        public int ID { get; set; }
        public string Instruction { get; set; }
        public int RecipeID { get; set; }
        public int No { get; set; }

        [JsonIgnore]
        public virtual Recipe Recipe { get; set; }
    }
}