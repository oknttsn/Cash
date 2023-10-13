using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Cash.Entity.Concrate
{
    public class BaseEntity
    {
        public Guid Id { get; protected set; } = Guid.NewGuid();
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), DataMember]
        public DateTime CreatedDate { get; protected set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; protected set; }
        public bool? IsDeleted { get; protected set; }
        public Guid? IsDeletedByUserId { get; protected set; }
        public DateTime? DeletedDate { get; protected set; }
        public void Delete(Guid? isDeletedByUserId)
        {
            IsDeleted = true;
            DeletedDate = DateTime.UtcNow;
            IsDeletedByUserId = isDeletedByUserId;
        }
    }
}
