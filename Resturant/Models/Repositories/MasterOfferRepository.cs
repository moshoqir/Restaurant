
using Resturant.Data;

namespace Resturant.Models.Repositories
{
    public class MasterOfferRepository : IRepository<MasterOffer>
    {
        public AppDbContext db { get; }
        public MasterOfferRepository(AppDbContext _db)
        {
            db = _db;
        }

        

        public void Active(int Id)
        {
            var entity = Find(Id);

            entity.IsActive = !entity.IsActive;

            entity.UpdateId = "";

            db.MasterOffers.Update(entity);
            db.SaveChanges();
        }

        public void Add(MasterOffer entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;

            entity.CreateId = "";
            entity.UpdateId = "";

            db.MasterOffers.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterOffer entity)
        {
            entity = Find(Id);

            entity.IsDelete = true;

            entity.UpdateId = "";

            db.MasterOffers.Update(entity);
            db.SaveChanges();
        }

        public MasterOffer Find(int Id)
        {
            return db.MasterOffers.
                SingleOrDefault(x => x.MasterOfferId == Id);
        }

        public void Update(int Id, MasterOffer entity)
        {
            entity.UpdateId = "";

            db.MasterOffers.Update(entity);
            db.SaveChanges();
        }

        public List<MasterOffer> ViewAdmin()
        {
            return db.MasterOffers.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterOffer> ViewClient()
        {
            return db.MasterOffers.
                Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
