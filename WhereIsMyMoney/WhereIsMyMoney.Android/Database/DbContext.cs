using System;
using System.IO;

namespace WhereIsMyMoney.Database
{
	public class DbContext : SQLite.SQLiteConnection
	{

		public static string DatabaseFilePath
		{
			get
			{ 

				string sqliteFilename = "wimm.db3";

				#if NETFX_CORE
				var path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, sqliteFilename);
				#else

				#if SILVERLIGHT
				// Windows Phone expects a local path, not absolute
				var path = sqliteFilename;
				#else

				#if __ANDROID__
				// Just use whatever directory SpecialFolder.Personal returns
				string libraryPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
				;
				#else
				// we need to put in /Library/ on iOS5.1 to meet Apple's iCloud terms
				// (they don't want non-user-generated data in Documents)
				string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
				string libraryPath = Path.Combine (documentsPath, "../Library/"); // Library folder
				#endif
				var path = Path.Combine (libraryPath, sqliteFilename);
				#endif		

				#endif
				return path;	
			}
		}

		public DbContext () : base (DatabaseFilePath)
		{
			CreateTable<WhereIsMyMoney.Models.Transaction> ();
			CreateTable<WhereIsMyMoney.Models.Category> ();
		}

		public SQLite.TableQuery<WhereIsMyMoney.Models.Transaction> Transactions { get; set; }

		public SQLite.TableQuery<WhereIsMyMoney.Models.Category> Categories { get; set; }


	}
}

