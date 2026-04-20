
using Resturant.Data;

namespace Resturant.Models.Repositories
{
    public class TransactionBookTableRepository : IRepository<TransactionBookTable>
    {
        public AppDbContext db { get; }
        public TransactionBookTableRepository(AppDbContext _db)
        {
            db = _db;
        }

        

        public void Active(int Id)
        {
          // We don't need it in Transactions tables
        }

        public void Add(TransactionBookTable entity)
        {
            entity.CreateId = "";

            db.TransactionBookTables.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, TransactionBookTable entity)
        {
            // Not needed? (check if we want f.ex to delete a booking?!)
        }

        public TransactionBookTable Find(int Id)
        {
            return db.TransactionBookTables.
                SingleOrDefault(x => x.TransactionBookTableId == Id);
        }

        public void Update(int Id, TransactionBookTable entity)
        {
            // Not needed? (check if we want f.ex to update a booking data)
        }

        public List<TransactionBookTable> ViewAdmin()
        {
            return db.TransactionBookTables.ToList();
        }

        public List<TransactionBookTable> ViewClient()
        {
            throw new NotImplementedException();
        }
    }
}
