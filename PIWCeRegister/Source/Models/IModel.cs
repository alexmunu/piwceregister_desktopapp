﻿using PIWCeRegister.Source.Models;
using System;

namespace PIWCeRegister.Source.Models
{
    public interface IModel<T> : IEquatable<T>  where T:class 
    {

    }
}