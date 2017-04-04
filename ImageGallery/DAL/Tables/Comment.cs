using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Tables
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
       

        //ForeignKeys
        public Guid? PhotoRefID { get; set; }
        [ForeignKey(name: "PhotoRefID")]
        public virtual Photo Photo { get; set; }

        public Guid? AlbumRefID { get; set; }
        [ForeignKey(name: "AlbumRefID")]
        public virtual Album Album { get; set; }

        public Guid? UserRefID { get; set; }
        [ForeignKey(name: "UserRefID")]
        public virtual User User { get; set; }
    }
}
