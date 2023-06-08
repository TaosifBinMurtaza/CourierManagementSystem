using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("User Name")]
        public string UserName { get; set; }

        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } = null;

    }
}
