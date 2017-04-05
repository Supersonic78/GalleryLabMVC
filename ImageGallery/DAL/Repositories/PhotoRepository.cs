using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Tables;
using System.Data.Entity;

namespace DAL.Repositories
{
    class PhotoRepository
    {
        public List<Photo> Get()
        {
            using (var ctx = new GalleryContext())
            {
                return ctx.Photos.Include(x => x.Comments).ToList();
            }
        } 
    }
}
