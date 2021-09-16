﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
namespace GoSearchSAE.Util
{
    [Serializable]
    public abstract class PropertyNotifier : INotifyPropertyChanged
    {
        public PropertyNotifier() { }
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
        // invokes the method on property change for given propertyName
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}