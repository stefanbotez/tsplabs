namespace EFstudii
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SelfReference")]
    public partial class SelfReference
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SelfReference()
        {
            SelfReference1 = new HashSet<SelfReference>();
        }

        public int SelfReferenceId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? ParentSelfReferenceId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SelfReference> SelfReference1 { get; set; }

        public virtual SelfReference SelfReference2 { get; set; }
    }
}
