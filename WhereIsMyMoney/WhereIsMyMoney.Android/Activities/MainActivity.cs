
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
	[Activity (Label = "WhereIsMyMoney.Android", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.MyButton);

			button.Click += delegate
			{
				button.Text = string.Format ("{0} clicks!", count++);


				var dao = new TransactionDAO();

				var r = new Random();

				var dr = Math.Round( r.NextDouble(), 2);

				var t = new Transaction{Value = dr + r.Next(100)};

				dao.Insert(t);

				var tresult = dao.GetByID(t);

				button.Text = string.Format("id {0}, value {1}", tresult.ID, tresult.Value);

			};



		}


	}
}

