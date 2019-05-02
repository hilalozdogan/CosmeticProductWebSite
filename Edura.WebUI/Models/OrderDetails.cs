using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.WebUI.Models
{
    public class OrderDetails
    {
        [Required(ErrorMessage ="Lütfen bir adres tanımı giriniz")]
        public string AdresTanimi { get; set; }

        [Required(ErrorMessage = "Lütfen bir adres giriniz")]
        public string Adres { get; set; }

        [Required(ErrorMessage = "Lütfen bir şehir giriniz")]
        public string Sehir { get; set; }

        [Required(ErrorMessage = "Lütfen bir semt giriniz")]
        public string Semt { get; set; }

        [Required(ErrorMessage = "Lütfen bir telefon numarası giriniz")]
        public string Telefon { get; set; }
    }
}
