//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace PIWCeRegister.Source.Models
{
    using System;
    using System.Collections.Generic;
    
    [DataContract]
    public partial class ch_services     :IModel
    {
        public ch_services()
        {
            this.members = new HashSet<member>();
        }
    
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public Nullable<int> Type { get; set; }
        [DataMember]
        public Nullable<System.DateTime> Date { get; set; }

        [DataMember]
        public virtual services_types services_types { get; set; }
        [DataMember]
        public virtual ICollection<member> members { get; set; }
    }
}
