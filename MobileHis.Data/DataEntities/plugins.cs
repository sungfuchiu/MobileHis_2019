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
    
    public partial class plugins
    {
        public plugins()
        {
            this.domain2plugin = new HashSet<domain2plugin>();
        }
    
        public string KeyID { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
    
        public virtual ICollection<domain2plugin> domain2plugin { get; set; }
    }
}