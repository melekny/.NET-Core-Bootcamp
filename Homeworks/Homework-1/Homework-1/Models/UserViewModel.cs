using System;
using System.ComponentModel.DataAnnotations;

namespace Homework_1.Models
{    
    public class UserViewModel
    {
        public int Id { get; set; }

        // Creating necessary validations for each form field

        [Display(Name = "İsim")]
        [Required(ErrorMessage = "İsim alanı zorunludur!")]
        [RegularExpression("([a-zA-Z',.-]+( [a-zA-Z',.-]+)*){2,30}", ErrorMessage = "Geçersiz giriş! Lütfen tekrar deneyiniz.")]
        public string FirstName { get; set; }

        [Display(Name = "Soyisim")]
        [Required(ErrorMessage = "Soyisim alanı zorunludur!")]
        [RegularExpression("([a-zA-Z',.-]+( [a-zA-Z',.-]+)*){2,30}", ErrorMessage = "Geçersiz giriş! Lütfen tekrar deneyiniz.")]
        public string LastName { get; set; }

        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "E-mail alanı zorunludur!")]
        [RegularExpression("^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$", ErrorMessage = "Geçersiz giriş! Lütfen geçerli bir E-mail adresi giriniz.")]
        public string Email { get; set; }

        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre alanı zorunludur!")]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Geçersiz Şifre! Şifreniz; en az bir büyük harf, bir karakter ve bir sayı dahil olmak üzere 8 karakterden oluşmalıdır.")]
         public string Password { get; set; }
    }
}

