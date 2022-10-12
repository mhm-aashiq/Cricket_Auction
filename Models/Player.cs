using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Cricket_Auction.Models
{
    public class Player
    {
        [Key]

        [Required]
        public int PlayerID { get; set; }

        [Required(ErrorMessage = "Please enter First Name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter Last Name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter Username")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Password \"{0}\" must have {2} character", MinimumLength = 8)]
        [RegularExpression(@"^([a-zA-Z0-9@*#]{8,15})$", ErrorMessage = "Password must contain: Minimum 8 characters atleast 1 UpperCase Alphabet, 1 LowerCase      Alphabet, 1 Number and 1 Special Character")]
        public string Password { get; set; }

        //[Display(Name = "Confirm password")]
        //[Required(ErrorMessage = "Please enter confirm password")]
        //[Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        //[DataType(DataType.Password)]
        //public string Confirmpwd { get; set; }
        //public Nullable<bool> Is_Deleted { get; set; }


        [Required]
        [Display(Name = "Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail id is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter Batting")]
        [Display(Name = "Batting")]
        public string Batting { get; set; }


        [Required(ErrorMessage = "Please enter Balling")]
        [Display(Name = "Balling")]
        public string Balling { get; set; }

        //[Required(ErrorMessage = "Please enter Strike Rate")]
        [Display(Name = "Strike Rate")]
        public string StrikeRate { get; set; }

        //[Display(Name = "Price")]
        //public float Price { get; set; }

        //[Required(ErrorMessage = "Please enter Status")]
        [Display(Name = "Status")]
        public string Status { get; set; }

        //[Required(ErrorMessage = "Please choose profile image")]
        //[Display(Name = "Profile Picture")]
      

        public ICollection<Trophy> trophies { get; set; }


        //public Team Team { get; set; }

    }

    public enum Status 
    {
        Sold,
        Unsold  
    }
}
