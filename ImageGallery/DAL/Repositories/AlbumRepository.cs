using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DAL.Tables;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace DAL.Repositories
{
   public class AlbumRepository
    {
       public List<Album> Get(string email)
       {
           using (var ctx = new GalleryContext())
           {
               return ctx.Albums.Where(x => x.UserEmail == email).Include(x => x.Photos).Include(x => x.Comments).ToList();
           }
       }
        public Album Get(Guid id)
        {
            using (var ctx = new GalleryContext())
            {
                return ctx.Albums.Include(x => x.Photos).Include(x => x.Comments).FirstOrDefault(x => x.Id == id);
            }
        }

        public void AddOrUpdate(Album album)
        {
            using (var ctx = new GalleryContext())
            {

                var entityToAddORUpdate = ctx.Albums.FirstOrDefault(x => x.Id == album.Id) ?? new Album()
                {
                    Id = album.Id,
                    UserEmail = album.UserEmail
                };

                entityToAddORUpdate.Name = album.Name;          

                ctx.Albums.AddOrUpdate(entityToAddORUpdate);
                ctx.SaveChanges();
            }
        }
    }
}
