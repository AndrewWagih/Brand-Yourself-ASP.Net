//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BY_1._2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Skill
    {
        public int id { get; set; }
        public string skill_nam { get; set; }
        public Nullable<int> user_id { get; set; }
    
        public virtual Userr Userr { get; set; }
    }
}
