using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PerformanceEfCore.EFCore.Context;
using PerformanceEfCore.EFCore.Models;

namespace PerformanceEfCore.EFCore
{
    public static class Repo
    {
        public static Func<AdventureWorksContext, IEnumerable<ModelForTesting>> CompiledQuery =
            EF.CompileQuery((AdventureWorksContext db) =>
        db.Product
            .Select(x => new ModelForTesting
            {
                ProductId = x.ProductID,
                Class = x.Class,
                ModifiedDate = x.TransactionHistory.Select(th => th.ModifiedDate).FirstOrDefault(),
                CategoryName = x.ProductSubcategory.ProductCategory.Name,
                Email = x.ProductReview.Select(pr => pr.EmailAddress).FirstOrDefault()
            })
            .Take(100));

        public static List<ModelForTesting> GetComplexData(AdventureWorksContext db)
        {
            var rawSqlString = @"SELECT TOP(100) [x].ProductId, [x].[Class], (
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
  ON [x.ProductSubcategory].[ProductCategoryID] = [x.ProductSubcategory.ProductCategory].[ProductCategoryID]";
            return db.ModelForTestings.FromSql(rawSqlString).ToList();
        }
        public static List<ModelForTestingQueryType> GetComplexDataQueryType(AdventureWorksContext db)
        {
            var rawSqlString = @"SELECT TOP(100) [x].ProductId, [x].[Class], (
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
  ON [x.ProductSubcategory].[ProductCategoryID] = [x.ProductSubcategory.ProductCategory].[ProductCategoryID]";
            return db.ModelForTestingQueryType.FromSql(rawSqlString).ToList();
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
    public class ModelForTestingQueryType
    {
        public int ProductId { get; set; }
        public string Class { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CategoryName { get; set; }
        public string Email { get; set; }
    }
}
