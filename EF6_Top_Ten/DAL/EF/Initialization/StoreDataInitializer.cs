#region copyright
// // Copyright Information
// // ==============================
// // DAL - StoreDataInitializer.cs
// // All samples copyright Philip Japikse 
// // http://www.skimedic.com 2016/08/10
// // See License.txt for more information
// // ==============================
#endregion
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DAL.EF.Initialization
{
    //public class StoreDataInitializer:DropCreateDatabaseIfModelChanges<StoreContext>
    public class StoreDataInitializer :DropCreateDatabaseAlways<StoreContext>
    {
        protected override void Seed(StoreContext context)
        {
            StoreData.GetAllStoreRecords().ToList().ForEach(x => context.Categories.Add(x));

            StoreData.GetAccounts().ToList().ForEach(x=>context.Accounts.Add(x));
            //StoreData.GetAccounts().ToList().ForEach(x=>context.Accounts.AddOrUpdate(x));
            context.SaveChanges();
        }

    }
}
