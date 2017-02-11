#region copyright
// // Copyright Information
// // ==============================
// // DAL - AccountTransactionRepo.cs
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
    public class AccountTransactionRepo : RepoBase<AccountTransaction>,IRepo<AccountTransaction>
    {
        public AccountTransactionRepo():this(true)
        {
        }

        public AccountTransactionRepo(bool useLazyLoading) : base(useLazyLoading)
        {
            Table = Context.AccountTransactions;
        }

        public List<AccountTransaction> GetAll() =>
            Table.OrderBy(x => x.TransactionDate).ToList();

        public async Task<List<AccountTransaction>> GetAllAsync() => 
            await Table.OrderBy(x => x.TransactionDate).ToListAsync();
    }
}