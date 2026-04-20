
using Resturant.Data;

namespace Resturant.Models.Repositories
{
    public class TransactionContactUsRepository : IRepository<TransactionContactUs>
    {
        public AppDbContext db { get; }
        public TransactionContactUsRepository(AppDbContext _db)
        {
            db = _db;
        }

        

        public void Active(int Id)
        {
            // We don't need it in Transactions tables

        }

        public void Add(TransactionContactUs entity)
        {
            entity.CreateId = "";

            
            db.TransactionContactUs.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, TransactionContactUs entity)
        {
            // Not needed? (check if we want f.ex to delete a form?!)
        }

        public TransactionContactUs Find(int Id)
        {
            return db.TransactionContactUs.
                  SingleOrDefault(x => x.TransactionContactUsId == Id);
        }

        public void Update(int Id, TransactionContactUs entity)
        {
            // Not needed? (check if we want f.ex to update a form data)
        }

        public List<TransactionContactUs> ViewAdmin()
        {
            return db.TransactionContactUs
                 .ToList();
        }

        public List<TransactionContactUs> ViewClient()
        {
            throw new NotImplementedException();
        }
    }
}
