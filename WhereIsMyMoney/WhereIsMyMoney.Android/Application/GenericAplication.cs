using System;
using WhereIsMyMoney.DAO;
using System.Collections.Generic;

namespace WhereIsMyMoney.Application
{
	public abstract class GenericAplication<TEntity, D> 
		where TEntity: new()
		where D : GenericDAO<TEntity>
	{

		protected D dao;

		public GenericAplication ()
		{
			dao = Activator.CreateInstance<D> ();
		}

		public virtual void Save (TEntity entity)
		{
			dao.Save (entity);
		}

		public virtual TEntity FindByID (TEntity entity)
		{
			return dao.FindByID (entity);
		}

		public virtual IEnumerable<TEntity> GetList (TEntity entity)
		{
			return dao.GetList ();
		}

		public virtual int Count { get { return dao.Count (); } }

	}
}

