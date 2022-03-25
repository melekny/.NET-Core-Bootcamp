using System;
using System.ComponentModel.DataAnnotations;

namespace First_App_Validations.Models
{
    public class CustomerViewModel
    {
        public Guid Id { get; set; }

        // Validations


        [Display(Name = "Ad")]
        [Required(ErrorMessage = "Ad alanı zorunlu alandır.")]
        [StringLength(10, ErrorMessage = "Ad alanı 10 karakterden büyük olamaz.")]
        public string FirstName { get; set; }

        [Display(Name = "Soyad")]
        [Required(ErrorMessage = "Soyadı alanı zorunlu alandır.")]
        [StringLength(20, ErrorMessage = "Soyadı alanı 20 karakterden büyük olamaz.")]
        public string LastName { get; set; }

        [Display(Name = "Yaş")]
        [Required(ErrorMessage = "Yaş alanı zorunlu alandır.")]
        [RegularExpression("^(1[89]|[2-9][0-9])$", ErrorMessage = "Yaş alanı 18 ile 99 arasında olmalıdır.")]
        public string Age { get; set; }

        [Display(Name = "Adres")]
        [Required(ErrorMessage = "Adres alanı zorunlu alandır.")]
        [StringLength(100, ErrorMessage = "Adres alanı 100 karakterden büyük olamaz.")]
        public string Address { get; set; }

        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre alanı zorunlu alandır.")]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Geçersiz Şifre! Şifreniz; en az bir büyük harf, bir karakter ve bir sayı dahil olmak üzere 8 karakterden oluşmalıdır.")]
        public string Password { get; set; }

        [Display(Name = "Açıklama")]
        [StringLength(100, ErrorMessage = "Açıklama alanı 200 karakterden büyük olamaz.")]
        public string Description { get; set; }
    }
}

