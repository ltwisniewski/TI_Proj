using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using TI_Projekt.Models;

namespace TI_Projekt.ViewModel
{
    public class CompleteTripViewModel
    {
        public int TripId { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public String StartPlace { get; set; }
        public String DestinationPlace { get; set; }
        public int Distance { get; set; }
        public DateTime CreatedOn { get; set; }

        public List<PhotoModel> PhotoData { get; set; }
        public List<VideoModel> VideoData { get; set; }
    }
}