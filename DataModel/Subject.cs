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
    using System.Collections.Generic;
    
    public partial class Subject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Subject()
        {
            this.ProfessorSubjects = new HashSet<ProfessorSubjects>();
            this.StudentSubjects = new HashSet<StudentSubjects>();
            this.Subject11 = new HashSet<Subject>();
        }
    
        public int subjectId { get; set; }
        public string subject1 { get; set; }
        public double creditHours { get; set; }
        public bool isActive { get; set; }
        public Nullable<int> deptId { get; set; }
        public Nullable<int> preSubjectId { get; set; }
        public string day { get; set; }
        public Nullable<System.TimeSpan> timeFrom { get; set; }
        public Nullable<System.TimeSpan> timeTo { get; set; }
    
        public virtual Department Department { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProfessorSubjects> ProfessorSubjects { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentSubjects> StudentSubjects { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Subject> Subject11 { get; set; }
        public virtual Subject Subject2 { get; set; }
    }
}
