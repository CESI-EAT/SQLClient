using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLClient.Database
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNum { get; set; }
        public Role Role { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }

    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Log
    {
        public int Id { get; set; }
        public User User { get; set; }
        public DateTime TimeStamp { get; set; }
        public string type { get; set; }
    }
}
