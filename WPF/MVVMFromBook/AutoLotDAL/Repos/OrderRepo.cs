using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLotDAL.Models;

namespace AutoLotDAL.Repos
{
	public class OrderRepo:BaseRepo<Order>,IRepo<Order>
	{
	    public OrderRepo()
	    {
	        Table = Context.Orders;
	    }
		public int Delete(int id, byte[] timeStamp)
		{
			Context.Entry(new Order()
			{
				OrderId = id,
				Timestamp = timeStamp
			}).State = EntityState.Deleted;
			return SaveChanges();
		}

		public Task<int> DeleteAsync(int id, byte[] timeStamp)
		{
			Context.Entry(new Order()
			{
				OrderId = id,
				Timestamp = timeStamp
			}).State = EntityState.Deleted;
			return SaveChangesAsync();
		}
	}
}
