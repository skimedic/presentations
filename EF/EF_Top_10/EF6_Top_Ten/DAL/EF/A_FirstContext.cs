#region copyright
// // Copyright Information
// // ==============================
// // DAL - A_FirstContext.cs
// // All samples copyright Philip Japikse 
// // http://www.skimedic.com 2016/08/10
// // See License.txt for more information
// // ==============================
#endregion
using System.Data.Entity;

namespace DAL.EF
{
    public class FirstContext : DbContext
    {
        public FirstContext()
            : base("name=StoreContext")
        {

        }
        public virtual DbSet<FirstExample> Tables { get; set; }
        //public virtual DbSet<Foo> Foos { get; set; }

    }

    public class Foo
    {
        public int Id { get; set; }
    }

    public class FirstExample
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }

}