using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using MvcAdminCv.Models.Entity;

namespace MvcAdminCv.Repostories
{
    public class GenericRepository<T> where T : class, new()
    {
        CvSiteEntities1 db = new CvSiteEntities1();

        public List<T> List()
        {
            return db.Set<T>().ToList();
        }

        public void TAdd(T p)
        {
            db.Set<T>().Add(p);
            db.SaveChanges();
        }

        public void TDelete(T p)
        {
            db.Set<T>().Remove(p);
            db.SaveChanges();
        }

        public T TGet(int id)
        {
            return db.Set<T>().Find(id);
        }

        public void Tupdate(T p)
        {
            db.SaveChanges();
        }

        //silme işlemi yaparken kullanaçağımız seçme işlemi
        public T Find(Expression<Func<T, bool>> where)
        {
            return db.Set<T>().FirstOrDefault(where);
        }
    }
}