using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DunkinDonuts.DAL.EntityModels
{
    public class User
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public decimal AccountBalance { get; set; }
    }
}
