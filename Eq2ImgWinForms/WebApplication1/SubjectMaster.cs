//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    
    public partial class SubjectMaster
    {
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public bool SubjectIsActive { get; set; }
        public System.DateTime SubjectCreateOn { get; set; }
    
        public virtual SubSubjectMaster SubSubjectMaster { get; set; }
    }
}
