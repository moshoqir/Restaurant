
using Resturant.Data;

namespace Resturant.Models.Repositories
{
    public class MasterCategoryMenuRepository : IRepository<MasterCategoryMenu>
    {
        public AppDbContext db { get; }
        public MasterCategoryMenuRepository(AppDbContext _db)
        {
            db = _db;
        }

        

        public void Active(int Id)
        {
            // making var entity to find the record
            var entity = Find(Id);
            // updating IsActive by returning the opposite value
            entity.IsActive = !entity.IsActive;
            // getting the editId for admin logs
            entity.UpdateId = "";

            db.MasterCategoryMenus.Update(entity);
            db.SaveChanges();
        }
        
        public void Add(MasterCategoryMenu entity)
        {
            // returning, when default adding, IsDelete false and  IsActive true
            entity.IsDelete = false;
            entity.IsActive = true;

            // getting the CreateID for logs
            entity.CreateId = "";
            entity.UpdateId = "";

            db.MasterCategoryMenus.Add(entity);

            db.SaveChanges();
        }

        public void Delete(int Id, MasterCategoryMenu entity)
        {
            // find entity 
            entity = Find(Id);
            // make IsDelete = true
            entity.IsDelete = true;
            //get logs
            entity.UpdateId = "";

            db.MasterCategoryMenus.Update(entity);
            db.SaveChanges();
        }

        public MasterCategoryMenu Find(int Id)
        {
            return db.MasterCategoryMenus.
                SingleOrDefault(x => x.MasterCategoryMenuId == Id);
        }

        public void Update(int Id, MasterCategoryMenu entity)
        {
            entity.UpdateId = "";
            entity.CreateId = "";
            entity.IsActive = true;
            db.MasterCategoryMenus.Update(entity);
            db.SaveChanges();
        }

        public List<MasterCategoryMenu> ViewAdmin()
        {
            return db.MasterCategoryMenus.Where(x => x.IsDelete == false).
                ToList();
        }

        public List<MasterCategoryMenu> ViewClient()
        {
            return db.MasterCategoryMenus.
                Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
