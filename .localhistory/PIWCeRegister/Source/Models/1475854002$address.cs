//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Runtime.Serialization;
using PIWCeRegister.Source;
using ProtoBuf;

namespace PIWCeRegister.Source.Models
{
    using System;
    using System.Collections.Generic;

    [ProtoContract]
    [DataContract]
    public partial class address : IModel<address>
    {
        public address()
        {
            this.members = new HashSet<member>();
        }

        [ProtoMember(1)]
        [DataMember]
        public int Id { get; set; }

        [ProtoMember(2)]
        [DataMember]
        public Nullable<int> Street_no { get; set; }

        [ProtoMember(3)]
        [DataMember]
        public string Street_Name { get; set; }

        [ProtoMember(4)]
        [DataMember]
        public string PostCode { get; set; }

        [ProtoMember(5)]
        [DataMember]
        public string City { get; set; }

        [ProtoMember(6)]
        [DataMember]
        public string Country { get; set; }

        [ProtoMember(7, OverwriteList = true)]
        [DataMember]
        public virtual ICollection<member> members { get; set; }

        public bool Equals(IModel<address> other)
        {
            if (other == null) return false;

            return (
                (Country == ((address)other).Country)
                && (City == ((address)other).City)
                && (PostCode == ((address)other).PostCode)
                && (Street_Name == ((address)other).Street_Name) && (Street_no == ((address)other).Street_no)
            );
                                                                    
        }

        public bool Equals(address other)
        {
            if (other == null) return false;

            return (
                (Country == other.Country)
                && (City == other.City)
                && (PostCode == other.PostCode)
                && (Street_Name == other.Street_Name) && (Street_no == other.Street_no))
            ;
        }
    }
}
