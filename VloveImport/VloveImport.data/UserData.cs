using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VloveImport.data
{
    public class UserData
    {
        public int User_ID { get; set; }
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastLName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class UserGroup
    {
        public int Group_ID { get; set; }
        public string GroupName { get; set; }
        public string GroupRole { get; set; }
        public string GroupStatus { get; set; }
        //public List<UserPage> UserPage { get; set; }
    }
}
