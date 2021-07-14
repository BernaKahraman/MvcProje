using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public Message GetByID(int id)
        {
            return _messageDal.get(x => x.MessageID == id);
        }

        public List<Message> GetListInbox(string p)
        {
            return _messageDal.List(x => x.ReceiverMail == p);
        }

        public List<Message> GetListSendbox(string p)
        {
            return _messageDal.List(x => x.SenderMail == p);
        }

        public void MessageAdd(Message message)
        {
            _messageDal.Insert(message);
        }

        public void MessageDelete(Message message)
        {
            _messageDal.Delete(message);
        }

        public List<Message> MessageNoRead(string p)
        {
            return _messageDal.List(x => x.ReceiverMail == p).Where(y => y.MessageRead == true).ToList();
        }

        public List<Message> MessageRead(string p)
        {
            return _messageDal.List(x => x.ReceiverMail == p).Where(y => y.MessageRead == false).ToList();

        }

        public void MessageUpdate(Message message)
        {
            _messageDal.Update(message);
        }
    }
}
