
using Resturant.Data;

namespace Resturant.Models.Repositories
{
    public class MasterServiceRepository : IRepository<MasterService>
    {
        public AppDbContext db { get; }
        public MasterServiceRepository(AppDbContext _db)
        {
            db = _db;
        }

        

        public void Active(int Id)
        {
            var entity = Find(Id);

            entity.IsActive = !entity.IsActive;

            entity.UpdateId = "";

            db.MasterServices.Update(entity);
            db.SaveChanges();
        }

        public void Add(MasterService entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;

            entity.CreateId = "";
            entity.UpdateId = "";

            db.MasterServices.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterService entity)
        {
            entity = Find(Id);

            entity.IsDelete = true;

            entity.UpdateId = "";

            db.MasterServices.Update(entity);
            db.SaveChanges();
        }

        public MasterService Find(int Id)
        {
            return db.MasterServices.SingleOrDefault(x => x.MasterServiceId == Id);
        }

        public void Update(int Id, MasterService entity)
        {
            entity.UpdateId = "";

            db.MasterServices.Update(entity);
            db.SaveChanges();
        }

        public List<MasterService> ViewAdmin()
        {
            return db.MasterServices.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterService> ViewClient()
        {
            return db.MasterServices.
                Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
