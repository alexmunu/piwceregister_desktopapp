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
    public partial class member   :IModel
    {
        public member()
        {
            this.ch_services = new HashSet<ch_services>();
        }
         [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Pim_no { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Telephone_no { get; set; }
        [DataMember]
        public string Mobile_no { get; set; }
        [DataMember]
        public Nullable<int> Id_Address { get; set; }
        [DataMember]
        public Nullable<int> Id_Occupation { get; set; }
        [DataMember]
        public virtual address address { get; set; }
        [DataMember]
        public virtual m_occupation m_occupation { get; set; }
        [DataMember]
        public virtual ICollection<ch_services> ch_services { get; set; }
    }
}
