﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIWCeRegister.Source.Services
{
    public sealed class ProtoContext : DynamicObject
    {
        private readonly Dictionary<string, object> _properties;

        public List<T> GetPropertyValue<T>(string key) where T : class => (List<T>)_properties[key];

        public ProtoContext(Dictionary<string, object> properties)
        {
            _properties = properties;
        }

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return _properties.Keys;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (_properties.ContainsKey(binder.Name))
            {
                result = _properties[binder.Name];
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (_properties.ContainsKey(binder.Name))
            {
                _properties[binder.Name] = value;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
