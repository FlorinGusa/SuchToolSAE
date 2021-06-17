using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GoSearchSAE.Util
{
    [Serializable]
    public abstract class PropertyNotifier : INotifyPropertyChanged
    {
        public PropertyNotifier() { }

        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;


        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
