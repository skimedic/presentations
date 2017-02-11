#region copyright
// // Copyright Information
// // ==============================
// // DAL - StoreContextPartial.cs
// // All samples copyright Philip Japikse 
// // http://www.skimedic.com 2016/08/10
// // See License.txt for more information
// // ==============================
#endregion
using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using DAL.Models;

namespace DAL.EF
{
    public partial class StoreContext
    {
        public StoreContext(bool useMaterializedEvent)
            : this()
        {
            if (!useMaterializedEvent) return;
            var context = (this as IObjectContextAdapter).ObjectContext;
            
            context.ObjectMaterialized += _context_ObjectMaterialized;
            context.SavingChanges += _context_SavingChanges;
        }

        void _context_SavingChanges(object sender, EventArgs e)
        {
            //Sender is of type ObjectContext.  Can get current and original values, and 
            //cancel/modify the save operation as desired.
            var context = sender as ObjectContext; 
            if (context == null) return; 
            foreach (ObjectStateEntry item in 
                context.ObjectStateManager.GetObjectStateEntries(
                    EntityState.Modified | EntityState.Added))
            {
                if (!item.IsRelationship && 
                    (item.Entity.GetType() == typeof(ProductPhoto)))
                {
                    
                    //var photo = item.Entity as ProductPhoto; 
                    var modifiedProperties = item.GetModifiedProperties().ToList();
                    foreach (var prop in modifiedProperties)
                    {
                        item.RejectPropertyChanges(prop);
                    }
                }
            }
        }

        void _context_ObjectMaterialized(object sender, ObjectMaterializedEventArgs e)
        {
            var item = e.Entity as EntityBase;
            if (item != null)
            {
                item.IsChanged = false;
            }
        }
    }
}
