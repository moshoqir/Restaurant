
using Resturant.Data;

namespace Resturant.Models.Repositories
{
    public class MasterSliderRepository : IRepository<MasterSlider>
    {
        public AppDbContext db { get; }
        public MasterSliderRepository(AppDbContext _db)
        {
            db = _db;
        }

       

        public void Active(int Id)
        {
            var entity = Find(Id);

            entity.IsActive = !entity.IsActive;

            entity.UpdateId = "";

            db.MasterSliders.Update(entity);
            db.SaveChanges();
        }

        public void Add(MasterSlider entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;

            entity.CreateId = "";
            entity.UpdateId = "";

            db.MasterSliders.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterSlider entity)
        {
            entity = Find(Id);

            entity.IsDelete = true;

            entity.UpdateId = "";

            db.MasterSliders.Update(entity);
            db.SaveChanges();
        }

        public MasterSlider Find(int Id)
        {
            return db.MasterSliders.
                SingleOrDefault(x => x.MasterSliderId == Id);

        }

        public void Update(int Id, MasterSlider entity)
        {
            entity.UpdateId = "";

            db.MasterSliders.Update(entity);
            db.SaveChanges();
        }

        public List<MasterSlider> ViewAdmin()
        {
            return db.MasterSliders.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterSlider> ViewClient()
        {
            return db.MasterSliders.
                Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
