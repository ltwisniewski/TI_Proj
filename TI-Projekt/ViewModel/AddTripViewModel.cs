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
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public String StartPlace { get; set; }
        public String DestinationPlace { get; set; }
        public double Distance { get; set; }

        //[DataType(DataType.Upload)]
        //[Display(Name = "Upload Video")]
        //[Required(ErrorMessage = "Please choose file to upload.")]
        //public string VideoPath { get; set; }

        //[NotMapped]
        //public HttpPostedFileBase[] Photo { get; set; }


        //[Display(Name = "Upload Photo")]
        //[Required(ErrorMessage = "Please choose file to upload.")]
        //public string PhotoPath { get; set; }

        //[NotMapped]
        //public HttpPostedFileBase PhotoFile { get; set; }
    }
}