using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace HBGDatorServiceDAL.POCO
{
    public class UserAccount
    {
        [Key]
        public int UserID { get; set; }

        public bool Admin { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {6} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get { return _Password ?? ""; } set { _Password = value; } }

        [Compare("Password", ErrorMessage = "Plese confirm your password.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public bool RememberMe { get; set; }


        private string _Password { get; set; }
        private string _ConfirmPassword { get; set; }

    }
}
