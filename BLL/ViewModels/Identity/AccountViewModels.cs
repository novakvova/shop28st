using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ViewModels.Identity
{

    public enum UserStatus
    {
        Error = 0,
        Success = 1,
        DublicationError = 2
    }
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Електронна адреса")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запам'ятати мене?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Поле є обов'язковим")]
        [EmailAddress]
        [Display(Name ="Електронна адреса")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage ="Мінімальні довжина паролю {0}", 
            MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name ="Пароль")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Підтверження пароля не " +
            "співпадає з паролем")]
        [DataType(DataType.Password)]
        [Display(Name = "Підтверження пароль")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(maximumLength: 50)]
        [Display(Name ="Телефон")]
        
        public string Phone { get; set; }
    }

}
