
using Resturant.Data;

namespace Resturant.Models.Repositories
{
    public class TransactionNewsletterRepository : IRepository<TransactionNewsletter>
    {
        public AppDbContext db { get; }
        public TransactionNewsletterRepository(AppDbContext _db)
        {
            db = _db;
        }

        

        public void Active(int Id)
        {
            // We don't need it in Transactions tables

        }

        public void Add(TransactionNewsletter entity)
        {
            entity.CreateId = "";

            db.TransactionNewsletters.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, TransactionNewsletter entity)
        {
            // Not needed? (check if we want f.ex to delete a form?!)
        }

        public TransactionNewsletter Find(int Id)
        {
            return db.TransactionNewsletters.
                SingleOrDefault(x => x.TransactionNewsletterId == Id);
        }

        public void Update(int Id, TransactionNewsletter entity)
        {
            // Not needed? (check if we want f.ex to update a form data)
        }

        public List<TransactionNewsletter> ViewAdmin()
        {
            return db.TransactionNewsletters.ToList();
        }

        public List<TransactionNewsletter> ViewClient()
        {
            throw new NotImplementedException();
        }
    }
}
