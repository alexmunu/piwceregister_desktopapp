using PIWCeRegister.Source.Models;
using System;

namespace PIWCeRegister.Source.Models
{
    public interface IModel<T> : IEquatable<IModel<T>>  where T:class 
    {

    }
}