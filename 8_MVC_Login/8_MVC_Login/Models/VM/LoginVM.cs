using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _8_MVC_Login.Models.VM
{
    public class LoginVM
    {
        [
            EmailAddress(ErrorMessage = "E-Posta formatında giriş yapınız..."),
            Required(ErrorMessage = "E-posta Giriniz..."),
            DisplayName("E-Posta")
        ]
        public string Email { get; set; }
        [Required(ErrorMessage = "Şifre Giriniz...")]
        public string Password { get; set; }
        [DisplayName("Beni Hatırla")]
        public bool IsPersistant { get; set; }
    }
}