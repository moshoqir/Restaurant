
using Resturant.Data;

namespace Resturant.Models.Repositories
{
    public class SystemSettingRepository : IRepository<SystemSetting>
    {
        public AppDbContext db { get; }
        public SystemSettingRepository(AppDbContext _db)
        {
            db = _db;
        }

        

        public void Active(int Id)
        {
            var entity = Find(Id);

            entity.IsActive = !entity.IsActive; 

            entity.UpdateId = "";

            db.SystemSettings.Update(entity);
            db.SaveChanges();
        }

        public void Add(SystemSetting entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;

            entity.CreateId = "";
            entity.UpdateId = "";

            db.SystemSettings.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, SystemSetting entity)
        {
            entity = Find(Id);

            entity.IsDelete = true;

            entity.UpdateId = "";

            db.SystemSettings.Update(entity);
            db.SaveChanges();
        }

        public SystemSetting Find(int Id)
        {
            return db.SystemSettings.SingleOrDefault(x => x.SystemSettingId == Id);
        }

        public void Update(int Id, SystemSetting entity)
        {
            entity.UpdateId = "";

            db.SystemSettings.Update(entity);
            db.SaveChanges();
        }

        public List<SystemSetting> ViewAdmin()
        {
           return db.SystemSettings.Where(x => x.IsDelete == false).ToList();
        }

        public List<SystemSetting> ViewClient()
        {
          return db.SystemSettings.
                Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
