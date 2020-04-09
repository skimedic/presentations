// Copyright Information
// ==================================
// EntityFrameworkCore - EfCoreBasics - SortingPagingQueries.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/04/09
// See License.txt for more information
// ==================================

using System.Linq;
using EfCoreBasics.EfStructures;
using EfCoreBasics.Entities;

namespace EfCoreBasics
{
    public class SortingPagingQueries
    {
        private AwDbContext _context = null;

        public SortingPagingQueries()
        {
        }
        private void ResetContext()
        {
            _context = new AwDbContextFactory().CreateDbContext(null);
        }


    }
}