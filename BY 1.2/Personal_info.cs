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
    
    public partial class Personal_info
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public string birthday { get; set; }
        public string profession { get; set; }
        public string address { get; set; }
        public Nullable<int> user_id { get; set; }
    
        public virtual Userr Userr { get; set; }
    }
}