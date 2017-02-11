#region copyright
// // Copyright Information
// // ==============================
// // EFCore_Top_Ten_Tests - DatabaseUtilities.cs
// // All samples copyright Philip Japikse 
// // http://www.skimedic.com 2016/08/10
// // See License.txt for more information
// // ==============================
#endregion
using EFCore_Top_Ten.EF;
using Microsoft.EntityFrameworkCore;

namespace EFCore_Top_Ten_Tests.Utilities
{
    public static class DatabaseUtilities
    {
        public static void CleanDataBase(StoreContext context, string tableName)
        {
            context.Database.ExecuteSqlCommand($"Delete from {tableName}");
            context.Database.ExecuteSqlCommand($"DBCC CHECKIDENT (\"{tableName}\", RESEED, 1);");

        }
    }
}
