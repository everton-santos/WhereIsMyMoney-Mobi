
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace WhereIsMyMoney.Models
{
	public class Transaction
	{
		[SQLite.PrimaryKey, SQLite.AutoIncrement]
		public int ID { get; set; }

		[SQLite.Indexed]
		public int IDCategory { get; set; }

		public TransactionType Type { get; set; }

		public double Value { get; set; }

		public DateTime DateTime { get; set; }

		public string Note { get; set; }
	}

	public enum TransactionType { CashIn, CashOut}
}

