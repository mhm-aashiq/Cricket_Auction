using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cricket_Auction.Models
{
    public class Trophy
    {
        [Key]

        [Required]
        public int TrophyID { get; set; }

        //// Foreign key   
        //[Display(Name = "Player")]
        //public virtual int PlayerID { get; set; }

        //[ForeignKey("PlayerID")]
        //public virtual Player Players { get; set; }


        //// Foreign key   
        //[Display(Name = "Team")]
        //public virtual int TeamID { get; set; }

        //[ForeignKey("TeamID")]
        //public virtual Team Team { get; set; }


        [Display(Name = "Type")]
        public string Type { get; set; }


        [Display(Name = "Color")]
        public string Color { get; set; }


        [Display(Name = "Name")]
        public string Name { get; set; }


        [Display(Name = "Material")]
        public string Material { get; set; }


        [Display(Name = "Description")]
        public string Description { get; set; }

        public Player player { get; set; }

    }
}
