using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsessLayer.Abstract
{
    public interface IRepository<T>
    {
        List<T> List();
        void Insert(T p);

        //sileceğimiz değeri bulmak için 
        T get(Expression<Func<T, bool>>filter); //get isminde metot tanımlandım
        void Delete(T p);
        void Update(T p);

        List<T> List(Expression<Func<T, bool>> filter);
    }
}
