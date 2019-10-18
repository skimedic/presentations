using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFCore3.EfStructures;
using Microsoft.EntityFrameworkCore;

namespace EFCore3
{
    public class PerformanceMethods
    {
        public static List<ModelForTesting> GetComplexData(AW2016Context db)
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
            return db.ModelsForTesting.FromSqlRaw(rawSqlString).ToList();
        }

    }
}
