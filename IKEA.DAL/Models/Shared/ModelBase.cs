using System;

namespace IKEA.DAL.Models.Shared
{
    public abstract class ModelBase
    {
        public int Id { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
