using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Cricket_Auction.Models
{
    public class Team
    {
        [Key]

        [Required]
        public int TeamID { get; set; }

        //// Foreign key   
        //[Display(Name = "TeamOwner")]
        //public virtual int TeamOwnerID { get; set; }

        //[ForeignKey("TeamOwnerID")]
        //public virtual TeamOwner TeamOwners { get; set; }


        //[Required(ErrorMessage = "Please enter Last Name")]
        [Display(Name = "Team Name")]
        public string TeamName { get; set; }


        //// Foreign key   
        //[Display(Name = "Player")]
        //public virtual int PlayerID { get; set; }

        //[ForeignKey("PlayerID")]
        //public virtual Player Players { get; set; }




        //[Required(ErrorMessage = "Please enter Last Name")]
        [Display(Name = "Price")]
        public float Price { get; set; }


        //public ICollection<Player> players { get; set; }



        public int TeamOwnerID { get; set; }
        public TeamOwner TeamOwner { get; set; }

    }

}