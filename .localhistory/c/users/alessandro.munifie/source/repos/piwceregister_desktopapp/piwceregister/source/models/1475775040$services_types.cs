//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PIWCeRegister.Source.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class services_types :IModel
    {
        public services_types()
        {
            this.ch_services = new HashSet<ch_services>();
        }
    
        public int Id { get; set; }
        public string Type_Name { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<ch_services> ch_services { get; set; }
    }
}
