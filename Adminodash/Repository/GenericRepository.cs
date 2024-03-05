using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Adminodash.Context;

namespace Adminodash.Repository
{
    public class GenericRepository<T> where T:class ,new()
    {
        AdminContext db = new AdminContext();

        public List<T> List()
        {
            return db.Set<T>().ToList();
        }
        public void Tadd(T p)
        {
            db.Set<T>().Add(p);
            db.SaveChanges();
        }
        public void Tdelete(T p)
        {
            db.Set<T>().Remove(p);
            db.SaveChanges();
        }
        public T Tget(int id)
        {
            return db.Set<T>().Find(id);
        }
        public T find(Expression<Func<T, bool>> where)
        {
            return db.Set<T>().FirstOrDefault(where);
        }

        public void TUpdate(T p)
        {
            db.Entry(p).State = EntityState.Modified;
            db.SaveChanges();
        }

    }
}