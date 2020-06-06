using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _6_Filter_Bundle.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthYear { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string TCKN { get; set; }

    }
}