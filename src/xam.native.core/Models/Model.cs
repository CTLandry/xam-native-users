using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SQLite;

namespace xam.native.core.Models
{
    public abstract class Model : IModel
    {
        [PrimaryKey]
        public string Id { get; }

        protected Model(string Id)
        {
            this.Id = Id;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value)) return false;
            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string GetModelPrimaryKey()
        {
            return this.Id;
        }

        public string GetModelName()
        {
            return this.GetType().Name;
        }
    }
}
