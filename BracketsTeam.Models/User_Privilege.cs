using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketsTeam.Models
{
    public class User_Privilege
    {
        public User_Privilege() { }

        public int IdUser_Privilege { get; set; }
        public int IdUser { get; set; }
        public int IdPrivilege { get; set; }

        public virtual User User { get; set; }
        public virtual Privilege Privilege { get; set; }
    }
}
