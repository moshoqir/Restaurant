
using Resturant.Data;

namespace Resturant.Models.Repositories
{
    public class MasterMenuRepository : IRepository<MasterMenu>
    {
        public AppDbContext db { get; }
        public MasterMenuRepository(AppDbContext _db)
        {
            db = _db;
        }

        

        public void Active(int Id)
        {
            var entity = Find(Id);

            entity.IsActive = !entity.IsActive;

            entity.UpdateId = "";

            db.MasterMenus.Update(entity);
            db.SaveChanges();
        }

        public void Add(MasterMenu entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;

            entity.CreateId = "";
            
            entity.UpdateId = "";
            
            db.MasterMenus.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterMenu entity)
        {
            entity = Find(Id);

            entity.IsDelete = true;

            entity.UpdateId = "";

            db.MasterMenus.Update(entity);
            db.SaveChanges();
        }

        public MasterMenu Find(int Id)
        {
            return db.MasterMenus
                .SingleOrDefault(x => x.MasterMenuId == Id);
        }

        public void Update(int Id, MasterMenu entity)
        {
            entity.UpdateId = "";
            entity.CreateId = "";
            entity.IsActive = true;
            db.MasterMenus.Update(entity);
            db.SaveChanges();
        }

        public List<MasterMenu> ViewAdmin()
        {
            return db.MasterMenus.Where(x => x.IsDelete == false).ToList();
            

        }

        public List<MasterMenu> ViewClient()
        {
            return db.MasterMenus.
                Where(x => x.IsDelete == false && x.IsActive == true && !x.MasterMenuUrl.StartsWith("/Admin")).ToList();
        }
    }
}
