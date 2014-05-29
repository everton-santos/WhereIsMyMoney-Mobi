
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

namespace WhereIsMyMoney.Android
{
	public class Transaction: AbstractEntity
	{
		public int IDCategory { get; set; }
		public double Value { get; set; }
		public DateTime DateTime { get; set; }
	}
}

