#region copyright
// // Copyright Information
// // ==============================
// // EFCore_Top_Ten - AccountRepo.cs
// // All samples copyright Philip Japikse 
// // http://www.skimedic.com 2016/08/10
// // See License.txt for more information
// // ==============================
#endregion
using System.Collections.Generic;
using System.Threading.Tasks;
using EFCore_Top_Ten.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EFCore_Top_Ten.Repos
{
    public class AccountRepo:RepoBase<Account>,IRepo<Account>
    {
        public AccountRepo()
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
