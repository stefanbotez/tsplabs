namespace EFstudii
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<SelfReference> SelfReferences { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SelfReference>()
                .HasMany(e => e.SelfReference1)
                .WithOptional(e => e.SelfReference2)
                .HasForeignKey(e => e.ParentSelfReferenceId);
        }
    }
}
