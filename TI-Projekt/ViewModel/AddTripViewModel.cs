using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TI_Projekt.ViewModel
{
    public class AddTripViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Pole nie może być puste")]
        [MaxLength(100, ErrorMessage = "Słowo powinno zawierać maksymalnie 100 znaków"), MinLength(3, ErrorMessage = "Słowo powinno zawierać co najmniej 3 znaki")]
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Pole nie może być puste")]
        [MaxLength(100, ErrorMessage = "Słowo powinno zawierać maksymalnie 100 znaków"), MinLength(3, ErrorMessage = "Słowo powinno zawierać co najmniej 3 znaki")]
        public String StartPlace { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Pole nie może być puste")]
        [MaxLength(100, ErrorMessage = "Słowo powinno zawierać maksymalnie 100 znaków"), MinLength(3, ErrorMessage = "Słowo powinno zawierać co najmniej 3 znaki")]
        public String DestinationPlace { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Pole nie może być puste")]
        [Range(1, 1000, ErrorMessage = "Wskaż liczbę z zakresu 1-1000")]
        public double Distance { get; set; }
    }
}