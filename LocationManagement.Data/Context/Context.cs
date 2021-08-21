using LocationManagement.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace LocationManagement.Data
{
    public class Context : DbContext
    {
        public Context() : base("name=Entities")
        {
        }
   

        #region Location
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<City> Cities { get; set; }
       
        #endregion

       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
