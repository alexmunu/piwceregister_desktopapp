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
    public partial class non_member    :IModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Mobile_no { get; set; }
        [DataMember]
        public string Purpose { get; set; }
        [DataMember]
        public Nullable<int> Comment { get; set; }
    }
}
