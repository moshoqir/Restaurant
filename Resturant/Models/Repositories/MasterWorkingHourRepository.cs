
using Resturant.Data;

namespace Resturant.Models.Repositories
{
    public class MasterWorkingHourRepository : IRepository<MasterWorkingHour>
    {
        public AppDbContext db { get; }

        public MasterWorkingHourRepository(AppDbContext _db)
        {
            db = _db;
        }

        

        public void Active(int Id)
        {
            var entity = Find(Id);

            entity.IsActive = !entity.IsActive;

            entity.UpdateId = "";

            db.MasterWorkingHours.Update(entity);
            db.SaveChanges();
        }

        public void Add(MasterWorkingHour entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;

            entity.CreateId = "";
            entity.UpdateId = "";

            db.MasterWorkingHours.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterWorkingHour entity)
        {
            entity = Find(Id);

            entity.IsDelete = true;

            entity.UpdateId = "";
            db.MasterWorkingHours.Update(entity);
            db.SaveChanges();
        }

        public MasterWorkingHour Find(int Id)
        {
            return db.MasterWorkingHours.
                SingleOrDefault(x => x.MasterWorkingHourId == Id);
        }

        public void Update(int Id, MasterWorkingHour entity)
        {
            entity.UpdateId = "";

            db.MasterWorkingHours.Update(entity);
            db.SaveChanges();
        }

        public List<MasterWorkingHour> ViewAdmin()
        {
            return db.MasterWorkingHours.
                Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterWorkingHour> ViewClient()
        {
            return db.MasterWorkingHours.
                Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
