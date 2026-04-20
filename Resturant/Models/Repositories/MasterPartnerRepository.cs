
using Resturant.Data;

namespace Resturant.Models.Repositories
{
    public class MasterPartnerRepository : IRepository<MasterPartner>
    {
        public AppDbContext db { get; }
        public MasterPartnerRepository(AppDbContext _db)
        {
            db = _db;
        }

       

        public void Active(int Id)
        {
            var entity = Find(Id);

            entity.IsActive = !entity.IsActive;

            entity.UpdateId = "";

            db.MasterPartners.Update(entity);
            db.SaveChanges();
        }

        public void Add(MasterPartner entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;

            entity.CreateId = "";
            entity.UpdateId = "";

            db.MasterPartners.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterPartner entity)
        {
            entity = Find(Id);

            entity.IsDelete = true;

            entity.UpdateId= "";
            db.MasterPartners.Update(entity);
            db.SaveChanges();
            
            
        }

        public MasterPartner Find(int Id)
        {
            return db.MasterPartners.SingleOrDefault(x => x.MasterPartnerId == Id);
        }

        public void Update(int Id, MasterPartner entity)
        {
            entity.UpdateId = "";

            db.MasterPartners.Update(entity);
            db.SaveChanges();
        }

        public List<MasterPartner> ViewAdmin()
        {
            return db.MasterPartners.Where(x=> x.IsDelete == false).ToList();
        }

        public List<MasterPartner> ViewClient()
        {
            return db.MasterPartners.
                Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
