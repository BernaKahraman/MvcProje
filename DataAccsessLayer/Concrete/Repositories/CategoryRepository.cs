using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsessLayer.Concrete.Repositories
{
    public class CategoryRepository : ICategoryDal
    {

        Context c = new Context();
        DbSet<Category> _object;
        public void Delete(Category p)
        {
            _object.Remove(p);
            c.SaveChanges();
        }

        public Category get(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Insert(Category p)
        {
            _object.Add(p);
            c.SaveChanges();
        }

        public List<Category> List()
        {
            return _object.ToList();
        }

        public List<Category> List(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Category p)
        {
            c.SaveChanges();
        }
    }
}
