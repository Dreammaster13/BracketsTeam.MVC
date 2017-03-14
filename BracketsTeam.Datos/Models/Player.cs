using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketsTeam.Datos.Models
{
    public class Player
    {
        //public Player() { }

        [Key]
        public int IdPlayer { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string NickName { get; set; }
        public DateTime BirthDate { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
