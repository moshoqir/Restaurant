
using Resturant.Data;

namespace Resturant.Models.Repositories
{
    public class MasterFeedbackRepository : IRepository<MasterFeedback>
    {
        public AppDbContext db { get; }
        public MasterFeedbackRepository(AppDbContext _db)
        {
            db = _db;
        }

        

        public void Active(int Id)
        {
            var entity = Find(Id);

            entity.IsActive = !entity.IsActive;

            entity.UpdateId = "";

            db.MasterFeedbacks.Update(entity);
            db.SaveChanges();
        }

        public void Add(MasterFeedback entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;

            entity.CreateId = "";
            entity.UpdateId = "";
            entity.MasterFeedbackType = entity.MasterFeedbackType == null ? "Customer" : entity.MasterFeedbackType;
            db.MasterFeedbacks.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterFeedback entity)
        {
            entity = Find(Id);

            entity.IsDelete = true;

            entity.UpdateId = "";

            db.MasterFeedbacks.Update(entity);
            db.SaveChanges();
        }

        public MasterFeedback Find(int Id)
        {
            return db.MasterFeedbacks.SingleOrDefault(x => x.MasterFeedbackId == Id);
        }

        public void Update(int Id, MasterFeedback entity)
        {
            entity.UpdateId = "";
            
            entity.EditDate = DateTime.UtcNow ;
            db.MasterFeedbacks.Update(entity);
            db.SaveChanges();
        }

        public List<MasterFeedback> ViewAdmin()
        {
            return db.MasterFeedbacks.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterFeedback> ViewClient()
        {
            return db.MasterFeedbacks.
                Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
