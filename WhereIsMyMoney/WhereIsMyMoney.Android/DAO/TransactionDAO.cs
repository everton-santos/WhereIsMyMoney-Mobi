
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace WhereIsMyMoney.Android
{
	public class TransactionDAO: GenericDAO<Transaction>
	{

		protected override Transaction FromReader (Mono.Data.Sqlite.SqliteDataReader rd)
		{
			return new Transaction { ID= rd.GetInt32(rd.GetOrdinal("ID")), Value = rd.GetDouble(rd.GetOrdinal("Value")) };
		}

		public override Transaction GetByID (Transaction entity)
		{
			var sql = "select * from [Transaction] where ID = ?";

			var cmd = new Mono.Data.Sqlite.SqliteCommand (sql);

			cmd.Parameters.Add (new Mono.Data.Sqlite.SqliteParameter (System.Data.DbType.Int32) { Value = entity.ID });

			return Query (cmd).FirstOrDefault ();
		}

		public override Mono.Data.Sqlite.SqliteCommand GetDeleteCommand (Transaction entity)
		{
			throw new NotImplementedException ();
		}

		protected override Mono.Data.Sqlite.SqliteCommand GetInsertCommand (Transaction entity)
		{
			var sql = "insert into [Transaction] ( Value) values(@Value )";

			var cmd = new Mono.Data.Sqlite.SqliteCommand (sql);

			cmd.Parameters.Add (new Mono.Data.Sqlite.SqliteParameter (System.Data.DbType.Double) { Value = entity.Value, ParameterName = "@Value" });

			return cmd;
		}

		public override Mono.Data.Sqlite.SqliteCommand GetUpdateCommand (Transaction entity)
		{
			throw new NotImplementedException ();
		}
	}
}

