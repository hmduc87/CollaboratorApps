using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CollaboratorApp.Common
{
    public  class GenericRepository<C, T> :
    IGenericRepository<T>
        where T : class
        where C : DbContext, new()
    {

        private C _entities = new C();
        public C Context
        {

            get { return _entities; }
            set { _entities = value; }
        }

        public virtual IQueryable<T> GetAll()//Lấy Hết Giá Trị trong Database
        {

            IQueryable<T> query = _entities.Set<T>();
            return query;
        }

        public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)//Tìm kiếm theo điều kiện 
        {

            IQueryable<T> query = _entities.Set<T>().Where(predicate);
            return query;
        }

        public virtual void Add(T entity)//Thêm Mới
        {
            _entities.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)//Xóa
        {
            _entities.Set<T>().Remove(entity);
        }

      //  public virtual void Edit(T entity)
        //{
          //  _entities.Entry(entity).State = System.Data.EntityState.Modified;
      //  }

        public virtual void Save()//Save
        {
            _entities.SaveChanges();
        }
    }
}