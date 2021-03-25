using System.ComponentModel.DataAnnotations;

namespace Exchange.Domain.Entity
{
    public abstract class BusinessEntity
    {
        [Key]
        public int Id { get; set; }

        public override bool Equals(object? obj)
        {
            return obj != null && Id.Equals(((BusinessEntity)obj).Id);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }


}