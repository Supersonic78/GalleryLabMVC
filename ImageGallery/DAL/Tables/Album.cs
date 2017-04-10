using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Tables
{
    public class Album
    {
        public  ICollection <Photo> Photos { get; set; }
        public  ICollection <Comment> Comments { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set;}
        public string UserEmail { get; set; }

     
    }
}
