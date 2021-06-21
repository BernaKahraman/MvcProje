using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ITalentService
    {
        List<Talent> GetList();
        void TalentAdd(Talent talent);
        Talent GetByID(int id);
        void TalentDelete(Talent talent);
        void TalentUpdate(Talent talent);

    }
}
