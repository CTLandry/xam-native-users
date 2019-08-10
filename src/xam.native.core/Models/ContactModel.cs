using System;
namespace xam.native.core.Models
{
    public class ContactModel : Model , IContact
    {

        private readonly string ContactID;

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

        public ContactModel()
        {
            this.ContactID = Guid.NewGuid().ToString();
        }

        public ContactModel(string name)
        {
            this.ContactID = Guid.NewGuid().ToString();
            this.Name = name;
        }


    }
}
