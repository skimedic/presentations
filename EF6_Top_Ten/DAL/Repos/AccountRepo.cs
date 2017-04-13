#region copyright
// // Copyright Information
// // ==============================
// // DAL - AccountRepo.cs
// // All samples copyright Philip Japikse 
// // http://www.skimedic.com 2016/08/10
// // See License.txt for more information
// // ==============================
#endregion
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Repos
{
    public class AccountRepo:RepoBase<Account>,IRepo<Account>
    {
        public AccountRepo():this(true)
        {
        }

        public AccountRepo(bool useLazyLoading) : base(useLazyLoading)
        {
            Table = Context.Accounts;
        }

        public Account GetFirst() => Table.First();
        public List<Account> GetAll() =>
            Table.OrderBy(x => x.AccountNumber).ToList();

        public async Task<List<Account>> GetAllAsync() => 
            await Table.OrderBy(x => x.AccountNumber).ToListAsync();
    }
}
