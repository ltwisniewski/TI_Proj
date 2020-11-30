using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TI_Projekt.ViewModel
{
    public class DisplayShortTripViewModel
    {
        public int TripId { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public String StartPlace { get; set; }
        public bool IsDeleted { get; set; }
    }
}