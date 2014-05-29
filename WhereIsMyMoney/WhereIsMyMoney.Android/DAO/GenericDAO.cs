
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
using Mono.Data.Sqlite;
using System.IO;

namespace WhereIsMyMoney.Android
{
	public abstract class GenericDAO<TEntity> where TEntity : AbstractEntity
	{

		private TEntity entity = Activator.CreateInstance<TEntity> ();


		private SqliteConnection _conn;



		private const string dbFileName = "wimm.db";

		private string _path;

		public GenericDAO ()
		{
			var dir = System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal);

			_path = Path.Combine (dir, dbFileName);


			var exists = File.Exists (_path);

			if (!exists)
			{
				CreateTables ();

				SeedData ();
			}

		}


		private void OpenConnection ()
		{
			try
			{
				_conn = new SqliteConnection ("Data Source=" + _path);
				
				_conn.Open ();
			} catch (Exception ex)
			{
				throw new DataBaseException ("Erro ao abrir conexao", ex);
			}
		}

		private void CloseConnection ()
		{
			try
			{
				if (_conn.State != System.Data.ConnectionState.Closed)
				{
					_conn.Close ();
				}
			} catch (Exception ex)
			{
				throw new DataBaseException ("Erro ao fechar conexao", ex);
			}

		}


		private void CreateTables ()
		{
			try
			{
				OpenConnection ();

				var commands = new [] { "CREATE TABLE [Transaction] ( ID INTEGER PRIMARY KEY AUTOINCREMENT, IDCategory INTEGER, Value NUMERIC(15,3), DateTime NTEXT); " };


				foreach (var cmd in commands)
				{
					using (var c = _conn.CreateCommand ())
					{
						c.CommandText = cmd;
						var i = c.ExecuteNonQuery ();
					}
				}

				CloseConnection ();


			} catch (DataBaseException ex)
			{
				throw ex;
			}
		}

		private void SeedData ()
		{

		}

		public void Insert (TEntity entity)
		{
			OpenConnection ();

			var cmd = GetInsertCommand (entity);
		
			cmd.Connection = _conn;

			var result = cmd.ExecuteNonQuery ();

			if (result > 0)
			{
				cmd.CommandText = "select last_insert_rowid()";

				entity.ID = int.Parse( cmd.ExecuteScalar ().ToString());
			}
		}

		protected abstract SqliteCommand GetInsertCommand (TEntity entity);

		public void Update (TEntity entity)
		{
			var cmd = GetUpdateCommand (entity);
			ExecuteNonQuery (cmd);
		}

		public abstract SqliteCommand GetUpdateCommand (TEntity entity);

		public void Delete (TEntity entity)
		{
			var cmd = GetDeleteCommand (entity);
			ExecuteNonQuery (cmd);
		}

		public abstract SqliteCommand GetDeleteCommand (TEntity entity);


		public int ExecuteNonQuery (SqliteCommand cmd)
		{
			OpenConnection ();

			cmd.Connection = _conn;

			var i = cmd.ExecuteNonQuery ();

			CloseConnection ();

			return i;
		}

		public object ExecuteScalar(  SqliteCommand cmd)
		{
			OpenConnection ();

			cmd.Connection = _conn;

			var i = cmd.ExecuteScalar ();



			CloseConnection ();

			return i;
		}

		public abstract TEntity GetByID (TEntity entity);

		public ICollection<TEntity> Query (SqliteCommand cmd)
		{
			OpenConnection ();

			cmd.Connection = _conn;

			var rd = cmd.ExecuteReader ();

			ICollection<TEntity> list = new List<TEntity> ();

			while (rd.Read ())
			{
				list.Add (FromReader (rd));	
			}
			rd.Close ();

			return list;
		}



		protected abstract TEntity FromReader (SqliteDataReader rd);

		public class DataBaseException : Exception
		{

			public DataBaseException (string message) : base (message)
			{

			}

			public DataBaseException (string message, Exception innerException) : base (message, innerException)
			{
				
			}
		}

		public class Expression
		{

			public static void Where<T> (Func<T, int, bool> predicate)
			{

				if (predicate != null)
				{
					throw new Exception ();
				} else
				{

				}
			}

		}


	}
}

