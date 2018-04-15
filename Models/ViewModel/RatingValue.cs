using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeStorageAPI.Models.ViewModel
{
    public class RatingValue
    {
        public int RecipeID { get; set; }
        public double Value { get; set; }

        public RatingValue() { }

        public RatingValue(int recipeID, double value)
        {
            RecipeID = recipeID;
            Value = value;
        }
    }
}