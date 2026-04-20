
using Resturant.Data;

namespace Resturant.Models.Repositories
{
    public class MasterSocialMediaRepository : IRepository<MasterSocialMedia>
    {
        public AppDbContext db { get; }
        public MasterSocialMediaRepository(AppDbContext _db)
        {
            db = _db;
        }

        

        public void Active(int Id)
        {
            // make var of entity and find it by Id
            var entity = Find(Id);

            entity.IsActive = !entity.IsActive;

            entity.UpdateId = "";

            db.MasterSocialMedia.Update(entity);
            db.SaveChanges();
        }

        public void Add(MasterSocialMedia entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;

            entity.CreateId = "";
            entity.UpdateId = "";
            
            db.MasterSocialMedia.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterSocialMedia entity)
        {
            entity = Find(Id);

            entity.IsDelete = true;

            entity.UpdateId = "";

            db.MasterSocialMedia.Update(entity);
            db.SaveChanges();
        }

        public MasterSocialMedia Find(int Id)
        {
            return db.MasterSocialMedia.
                SingleOrDefault(x => x.MasterSocialMediaId == Id);
        }

        public void Update(int Id, MasterSocialMedia entity)
        {
            entity.UpdateId = "";

            db.MasterSocialMedia.Update(entity);
            db.SaveChanges();
        }

        public List<MasterSocialMedia> ViewAdmin()
        {
           return db.MasterSocialMedia.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterSocialMedia> ViewClient()
        {
            return db.MasterSocialMedia.
                Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
