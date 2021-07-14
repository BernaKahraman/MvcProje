using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetListInbox(string p);
        List<Message> GetListSendbox(string p);

        List<Message> MessageRead(string p);
        List<Message> MessageNoRead(string p);

        void MessageAdd(Message message);

        //bulma işlemi için
        Message GetByID(int id);
        void MessageDelete(Message message);
        void MessageUpdate(Message message);
        
    }
}
