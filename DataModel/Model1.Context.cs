//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class SoadEntities : DbContext
    {
        public SoadEntities()
            : base("name=SoadEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Level> Level { get; set; }
        public virtual DbSet<Professor> Professor { get; set; }
        public virtual DbSet<ProfessorSubjects> ProfessorSubjects { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentSubjects> StudentSubjects { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
    
        public virtual ObjectResult<Depts_Result> Depts()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Depts_Result>("Depts");
        }
    
        public virtual ObjectResult<Gend_Result> Gend()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Gend_Result>("Gend");
        }
    
        public virtual ObjectResult<Lev_Result> Lev()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Lev_Result>("Lev");
        }
    
        public virtual ObjectResult<Prof_Result> Prof()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Prof_Result>("Prof");
        }
    
        public virtual ObjectResult<ProSub_Result> ProSub()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ProSub_Result>("ProSub");
        }
    
        public virtual ObjectResult<Stud_Result> Stud()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Stud_Result>("Stud");
        }
    
        public virtual ObjectResult<StuSub_Result> StuSub()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<StuSub_Result>("StuSub");
        }
    
        public virtual ObjectResult<Sub_Result> Sub()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Sub_Result>("Sub");
        }
    }
}
