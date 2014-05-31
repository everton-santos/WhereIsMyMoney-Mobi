using System;
using WhereIsMyMoney.Database;
using System.Collections.Generic;
using System.Linq;


namespace WhereIsMyMoney.DAO
{
	public abstract class GenericDAO<TEntity> where TEntity: new()
	{
		protected DbContext db = null;

		protected static object locker = new object ();

		public GenericDAO ()
		{
			db = new DbContext ();
		}

		public IEnumerable<TEntity> GetList ()
		{
			lock (locker)
			{
				return db.Table<TEntity> ().ToList ();
			}
		}

		public abstract TEntity FindByID (TEntity entity);

		public void Save (TEntity entity)
		{
			lock (locker)
			{
				if (FindByID (entity) != null)
				{
					db.Update (entity);
				} else
				{
					db.Insert (entity);
				}
			}
		}

		public int Count
		{
			get
			{
				lock (locker)
				{
					return db.Table<TEntity> ().Count ();
				}
			}
		}
	}
}

