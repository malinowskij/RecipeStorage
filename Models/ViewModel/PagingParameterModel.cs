using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeStorageAPI.Models.ViewModel
{
    public class PagingParameterModel
    { 
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 12;
    }
}