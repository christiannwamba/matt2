//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MathewProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Structure
    {
        public int StructureID { get; set; }
        public string StructureType { get; set; }
        public Nullable<int> PriestID { get; set; }
        public string StructureName { get; set; }
        public string st { get; set; }
    
        public virtual Priest Priest { get; set; }
    }
}