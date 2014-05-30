using System;

namespace WhereIsMyMoney.Models
{
	public class Category
	{
		[SQLite.PrimaryKey, SQLite.AutoIncrement]
		public int ID { get; set; }

		public TransactionType TransactionType { get; set; }

		public string Description { get; set; }
	}
}

