using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeStorageAPI.Models.ViewModel
{
    public class RecipeCategoryCounter
    {
        public RecipeCategory RecipeCategory { get; set; }
        public int Amount { get; set; }

        public RecipeCategoryCounter(RecipeCategory recipeCategory, int amount)
        {
            RecipeCategory = recipeCategory;
            Amount = amount;
        }
    }
}