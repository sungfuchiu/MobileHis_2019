//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MobileHis.Data.DataEntities
{
    using System;
    using System.Collections.Generic;
    
    public partial class domains
    {
        public domains()
        {
            this.domain2plugin = new HashSet<domain2plugin>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string AccountType { get; set; }
        public Nullable<int> PatientLimit { get; set; }
        public Nullable<int> AccountLimit { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
    
        public virtual ICollection<domain2plugin> domain2plugin { get; set; }
    }
}
