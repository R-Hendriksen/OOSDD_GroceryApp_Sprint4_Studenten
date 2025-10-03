using Grocery.Core.Models;
using System.Globalization;

namespace Grocery.Core.Models
{
    public partial class Client : Model
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public Client(int id, string name, string emailAddress, string password) : base(id, name)
        {
            EmailAddress = emailAddress;
            Password = password;
            Role = Role.None;
        }

        public Client(int id, string name, string emailAddress, string password, Role role) : this(id, name, emailAddress, password)
        {
            Role = role;
        }
    }
}
