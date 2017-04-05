using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DAL.Tables;
using System.Data.Entity;

namespace DAL.Repositories
{
   public class AlbumRepository
    {
       public List<Album> Get(Guid id)
       {
           using (var ctx = new GalleryContext())
           {
               return ctx.Albums.Where(x => x.UserRefID == id).Include(x => x.Photos).Include(x => x.Comments).ToList();
           }
       }
    }
}
