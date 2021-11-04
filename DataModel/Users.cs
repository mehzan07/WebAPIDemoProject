using System;
using System.Collections.Generic;

namespace WebAPIDemoProject.DataModel
{
    public partial class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }

    }
}
