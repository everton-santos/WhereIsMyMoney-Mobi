using System;
using WhereIsMyMoney.Models;

namespace WhereIsMyMoney.DAO
{
	public class TransactionDAO : GenericDAO<Transaction>
	{
		#region implemented abstract members of GenericDAO

		public override Transaction FindByID (Transaction entity)
		{
			lock (locker)
			{
				return db.Table<Transaction> ().Where (x => x.ID == entity.ID).FirstOrDefault ();
			}
		}

		#endregion


	}
}

