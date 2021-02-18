using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework_4_7.API.Models
{
    public class User
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public UserRole UserRole { get; set; }
    }
}
