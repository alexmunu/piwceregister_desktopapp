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
    public partial class non_member : IModel<non_member>
    {
        [ProtoMember(1)]
        [DataMember]
        public int Id { get; set; }

        [ProtoMember(2)]
        [DataMember]
        public string FirstName { get; set; }

        [ProtoMember(3)]
        [DataMember]
        public string LastName { get; set; }

        [ProtoMember(4)]
        [DataMember]
        public string Mobile_no { get; set; }

        [ProtoMember(5)]
        [DataMember]
        public string Purpose { get; set; }

        [ProtoMember(6)]
        [DataMember]
        public Nullable<int> Comment { get; set; }

        public bool Equals(non_member other)
        {
            return (
                (FirstName == other.FirstName)
                && (LastName == other.LastName)
            );
        }
    }
}
