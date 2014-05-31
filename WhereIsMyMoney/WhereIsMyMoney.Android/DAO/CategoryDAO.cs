using System;
using WhereIsMyMoney.Models;
namespace WhereIsMyMoney.DAO
{
	public class CategoryDAO: GenericDAO<Category>
	{
		#region implemented abstract members of GenericDAO
		public override Category FindByID (Category entity)
		{
			lock (locker)
			{
				return db.Categories.Where (x => x.ID == entity.ID).FirstOrDefault ();
			}
		}
		#endregion
	}
}

