using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;

namespace RecipeStorageAPI.Controllers.Utils
{
    public static class IQueryableApplySortExtension
    {
        public static IQueryable<T> ApplySort<T>(this IQueryable<T> source, string strSort)
        {
            if (source == null)
                throw new ArgumentNullException("source", "DataSource is empty");

            if (strSort == null)
                return source;

            var lstSort = strSort.Split(',');
            string sortExpression = string.Empty;

            foreach (var sortOption in lstSort) 
            {
                if (sortOption.StartsWith("-"))
                {
                    sortExpression += sortOption.Remove(0, 1) + " descending,";
                } else
                {
                    sortExpression += sortOption + ",";
                }
            }

            if (!string.IsNullOrWhiteSpace(sortExpression))
            {
                source = source.OrderBy(sortExpression.Remove(sortExpression.Count() - 1));
            }

            return source;
        }
    }
}