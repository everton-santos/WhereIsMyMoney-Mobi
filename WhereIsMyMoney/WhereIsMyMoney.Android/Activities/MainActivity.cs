
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
				var dao = new DAO.TransactionDAO ();

				var r = new Random ();

				var value = Math.Round (r.NextDouble (), 2) + r.Next (1000);

				var t = new Models.Transaction () { IDCategory = 1, Note = "Test", DateTime = DateTime.Now, Value = value };

				dao.Save(t);

				button.Text = string.Format(" id = {0}, note = {1} , value = {2}", t.ID, t.Note, t.Value);
			};



		}


	}
}

