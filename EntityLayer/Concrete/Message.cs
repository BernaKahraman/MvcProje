using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }

        [StringLength(50)]
        public String SenderMail { get; set; }

        [StringLength(50)]
        public String ReceiverMail { get; set; }

        [StringLength(100)]
        public String Subject { get; set; }

        public String MessageContent { get; set; }

        public DateTime MessageDate { get; set; }

        public bool IsRead { get; set; }

       // public bool isDraft { get; set; }

    }
}
