using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Talent
    {
        [Key]
        public int TalentID { get; set; }

        [StringLength(15)]
        public string Name { get; set; }

        [StringLength(50)]
        public string About { get; set; }

        [StringLength(100)]
        public string Skill1 { get; set; }

        [StringLength(100)]
        public string Skill2 { get; set; }
        [StringLength(100)]
        public string Skill3 { get; set; }
        [StringLength(100)]
        public string Skill4 { get; set; }

        [StringLength(100)]
        public string Skill5 { get; set; }

        public int Rate1 { get; set; }
        public int Rate2 { get; set; }
        public int Rate3 { get; set; }
        public int Rate4 { get; set; }
        public int Rate5 { get; set; }
    }
}
