//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Runtime.Serialization;
using ProtoBuf;

namespace PIWCeRegister.Source.Models
{
    using System;
    using System.Collections.Generic;

    [ProtoContract]
    [DataContract]
    public partial class member : IModel<member>
    {
        public member()
        {
            this.ch_services = new HashSet<ch_services>();
        }

        [ProtoMember(1)]
        [DataMember]
        public int Id { get; set; }

        [ProtoMember(2)]
        [DataMember]
        public string Pim_no { get; set; }

        [ProtoMember(3)]
        [DataMember]
        public string FirstName { get; set; }

        [ProtoMember(4)]
        [DataMember]
        public string LastName { get; set; }

        [ProtoMember(5)]
        [DataMember]
        public string Telephone_no { get; set; }

        [ProtoMember(6)]
        [DataMember]
        public string Mobile_no { get; set; }

        [ProtoMember(7)]
        [DataMember]
        public Nullable<int> Id_Address { get; set; }

        [ProtoMember(8)]
        [DataMember]
        public Nullable<int> Id_Occupation { get; set; }

        [ProtoMember(9)]
        [DataMember]
        public virtual address address { get; set; }

        public virtual m_occupation m_occupation { get; set; }

       
        public virtual ICollection<ch_services> ch_services { get; set; }

        public bool Equals(member other)
        {
            if (other == null) return false;

            return (
                (FirstName == other.LastName));
        }
    }
}
