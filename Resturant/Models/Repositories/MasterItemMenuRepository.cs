
using Microsoft.EntityFrameworkCore;
using Resturant.Data;

namespace Resturant.Models.Repositories
{
    public class MasterItemMenuRepository : IRepository<MasterItemMenu>
    {
        public AppDbContext db { get; }
        public MasterItemMenuRepository(AppDbContext _db)
        {
            db = _db;
        }

        

        public void Active(int Id)
        {
            var entity = Find(Id);

            entity.IsActive = !entity.IsActive;

            entity.UpdateId = "";

            db.MasterItemMenus.Update(entity);
            db.SaveChanges();
        }

        public void Add(MasterItemMenu entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;

            entity.CreateId = "";
            entity.UpdateId = "";
            entity.CreateDate = DateTime.Now;
            db.MasterItemMenus.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterItemMenu entity)
        {
            entity = Find(Id);

            entity.IsDelete = true;

            entity.UpdateId = "";

            db.MasterItemMenus.Update(entity);
            db.SaveChanges();
        }

        public MasterItemMenu Find(int Id)
        {
            return db.MasterItemMenus
                .Include(m => m.MasterCategoryMenu)
                 .SingleOrDefault(x => x.MasterItemMenuId == Id);
        }

        public void Update(int Id, MasterItemMenu entity)
        {
            entity.UpdateId = "";
            entity.CreateId = "";

            db.MasterItemMenus.Update(entity);
            db.SaveChanges();
        }

        public List<MasterItemMenu> ViewAdmin()
        {
            return db.MasterItemMenus.Where(x => x.IsDelete == false)
                .Include(m => m.MasterCategoryMenu).ToList();

        }

        public List<MasterItemMenu> ViewClient()
        {
            return db.MasterItemMenus.
                Where(x => x.IsDelete == false && x.IsActive == true)
                .Include(m => m.MasterCategoryMenu).ToList();
        }
    }
}
