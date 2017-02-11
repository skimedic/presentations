#region copyright
// // Copyright Information
// // ==============================
// // EFCore_Top_Ten - AccountTransactionRepo.cs
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
    public class AccountTransactionRepo : RepoBase<AccountTransaction>,IRepo<AccountTransaction>
    {
        public AccountTransactionRepo()
        {
            Table = Context.AccountTransactions;
        }

        public List<AccountTransaction> GetAll() =>
            Table.OrderBy(x => x.TransactionDate).ToList();

        public async Task<List<AccountTransaction>> GetAllAsync() => 
            await Table.OrderBy(x => x.TransactionDate).ToListAsync();
    }
}