//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Zoopark
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ZooEntities : DbContext
    {
        public ZooEntities()
            : base("name=ZooEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Animal> Animal { get; set; }
        public virtual DbSet<Bird> Bird { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Feeding_Ration> Feeding_Ration { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Habitat> Habitat { get; set; }
        public virtual DbSet<Reptile> Reptile { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Type_Employee> Type_Employee { get; set; }
        public virtual DbSet<Type_Feeding_Ration> Type_Feeding_Ration { get; set; }
        public virtual DbSet<Wintering_Place> Wintering_Place { get; set; }
    }
}
