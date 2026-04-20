namespace Resturant.Models
{
    public class BaseEntity
    {
        public bool IsDelete { get; set; }

        public bool IsActive { get; set; }

        public string? CreateId { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.UtcNow;

        public string? UpdateId { get; set; }

        public DateTime EditDate { get; set; } = DateTime.UtcNow;



    }

    public class TransBaseEntity
    {
        public string? CreateId { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
    }
}
