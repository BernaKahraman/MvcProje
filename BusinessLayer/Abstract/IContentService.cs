using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetList(string p);
        List<Content> GetListByWriter(int id);
        List<Content> GetListByHeadingID(int id); //id göre bütün listeyi döndürür
        void ContentAdd(Content content);

        //bulma işlemi için
        Content GetByID(int id);
        void ContentDelete(Content content);
        void ContentUpdate(Content content);

    }
}
