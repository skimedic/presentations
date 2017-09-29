using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PerformanceEfCore.EFCore
{
    public static class Repo
    {
        public static void GetComplexData(PerformanceEfCore.EFCore.Context.AdventureWorksContext db)
        {
            var el = db.ModelForTestings.FromSql(@"SELECT TOP(100) [x].ProductId, [x].[Class], (
    SELECT TOP(1) [th].[ModifiedDate]
    FROM [Production].[TransactionHistory] AS [th]
    WHERE [x].[ProductID] = [th].[ProductID]
) AS [ModifiedDate], [x.ProductSubcategory.ProductCategory].[Name] AS [CategoryName], (
    SELECT TOP(1) [pr].[EmailAddress]
    FROM [Production].[ProductReview] AS [pr]
    WHERE [x].[ProductID] = [pr].[ProductID]
) AS [Email]
FROM [Production].[Product] AS [x]
LEFT JOIN [Production].[ProductSubcategory] AS [x.ProductSubcategory] ON [x].[ProductSubcategoryID] = [x.ProductSubcategory].[ProductSubcategoryID]
LEFT JOIN [Production].[ProductCategory] AS [x.ProductSubcategory.ProductCategory] 
  ON [x.ProductSubcategory].[ProductCategoryID] = [x.ProductSubcategory.ProductCategory].[ProductCategoryID]").ToList();

        }
    }

    public class ModelForTesting
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductId { get; set; }
        public string Class { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CategoryName { get; set; }
        public string Email { get; set; }

    }
}
