using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Tables;

namespace DAL
{
   public class GalleryContext : DbContext
    {
        DbSet<Album> Albums { get; set; }
        DbSet<Photo> Photos { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<User> Users { get; set; }

        public System.Data.Entity.DbSet<DAL.Tables.Photo> Photos { get; set; }

        public System.Data.Entity.DbSet<DAL.Tables.Album> Albums { get; set; }
    }
}
