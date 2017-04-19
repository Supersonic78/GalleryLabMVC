using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Tables;
using System.Data.Entity;

namespace DAL.Repositories
{
   public class PhotoRepository
    {
        public List<Photo> Get()
        {
            using (var ctx = new GalleryContext())
            {
                return ctx.Photos.Include(x => x.Comments).ToList();
            }
        }

       public void Clear()
       {
           using (var ctx = new GalleryContext())
           {
               var photos = ctx.Photos;
               ctx.Photos.RemoveRange(photos);
           }
       }

        public ICollection<Photo> Get(Guid id)
        {
            using (var ctx = new GalleryContext())
            {
            
               var  photos =(ctx.Photos.Where(x => x.AlbumRefID == id).ToList()) ?? new List<Photo>();
                return photos;
            }
        }

        public void Add(Photo photo)
        {
            throw new NotImplementedException();
        }
    }
}
