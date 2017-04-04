using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Tables;

namespace DAL.Repositories
{
   public class AlbumRepository
    {
       public List<Album> Get()
       {
           using (var ctx = new GalleryContext())
           {
               return ctx.Albums.ToList();
           }
       }
    }
}
