using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Draft
    {
        [Key]
        public int DraftID { get; set; }

        [StringLength(50)]
        public string Mail { get; set; }

        [StringLength(100)]
        public string Subject { get; set; }

        public string MessageContent { get; set; }
        public DateTime MessageDate { get; set; }
    }
}
