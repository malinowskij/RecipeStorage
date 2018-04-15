using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecipeStorageAPI.Models
{
    public class Comment
    {
        public int ID { get; set; }

        [StringLength(5000, MinimumLength = 5, ErrorMessage = "Wypełnij pole komentarza")]
        public string Content { get; set; }

        public DateTime CreatedTime { get; set; }

        public int RecipeID { get; set; }
        [JsonIgnore]
        public virtual Recipe Recipe { get; set; }

        public string ApplicationUserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}