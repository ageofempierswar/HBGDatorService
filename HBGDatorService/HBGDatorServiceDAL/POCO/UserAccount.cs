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

        [Required(ErrorMessage = "Förnamn måste fyllas i.")]
        [Display(Name = "Förnamn")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Efternamn måste fyllas i.")]
        [Display(Name = "Efternamn")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email måste fyllas i.")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Användarnamn måste fyllas i.")]
        [Display(Name = "Användarnamn")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Lösenord måste fyllas i.")]
        [Display(Name = "Lösenord")]
        [DataType(DataType.Password)]
        public string Password { get { return _Password ?? ""; } set { _Password = value; } }

        [Compare("Password", ErrorMessage = "Skriv in ditt lösenord igen.")]
        [Display(Name = "Bekräfta lösenordet")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public bool RememberMe { get; set; }


        private string _Password { get; set; }
        private string _ConfirmPassword { get; set; }

    }
}
