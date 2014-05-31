using System;
using WhereIsMyMoney.Models;
using WhereIsMyMoney.DAO;

namespace WhereIsMyMoney.Application
{
	public class TransactionApp : GenericAplication<Transaction, TransactionDAO>
	{
		public override void Save (Transaction entity)
		{
			if (entity.DateTime == null || entity.DateTime < new DateTime (2000, 1, 1))
			{
				entity.DateTime = DateTime.Now;
			}

			base.Save (entity);
		}

	}
}

