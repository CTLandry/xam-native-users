using System;
using SQLite;

namespace xam.native.core.Models
{
    [Table("Contacts")]
    public class ContactModel : Model , IContact, IModel
    {
        
        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }

        public ContactModel() : base(Guid.NewGuid().ToString())
        {
            
        }

        public ContactModel(string name) : base(Guid.NewGuid().ToString())
        {
            this.Name = name;
        }


    }
}
