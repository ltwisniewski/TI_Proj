using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TI_Projekt.Models;
using TI_Projekt.ViewModel;

namespace TI_Projekt.Controllers
{
    public class DetailsController : Controller
    {

        private TripDbContext db = new TripDbContext();
        public ActionResult Index()
        {
            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            CompleteTripViewModel CTVM = new CompleteTripViewModel();

            var trip = (from Trips in db.Trips


                where Trips.TripId==id
                select new
                {
                    Trips.TripId, 
                    Trips.Title, 
                    Trips.StartDate,
                    Trips.StartPlace,
                    Trips.EndDate,
                    Trips.DestinationPlace,
                    Trips.Distance,
                    Trips.CreatedOn,
                }
                ).ToList();

            foreach (var item in trip)
            {
                CTVM.TripId = item.TripId;
                CTVM.Title = item.Title;
                CTVM.StartDate = item.StartDate;
                CTVM.StartPlace = item.StartPlace;
                CTVM.EndDate = item.EndDate;
                CTVM.DestinationPlace = item.DestinationPlace;
                CTVM.Distance = item.Distance;
                CTVM.CreatedOn = item.CreatedOn;
            }

            CTVM.PhotoData = new List<PhotoModel>();


            var photoDataList = (from Photo in db.Photos
            where Photo.TripId == id
                                select new { Photo.PhotoName, Photo.PhotoSrc, Photo.PhotoId, Photo.TripId}).ToList();


            foreach (var item in photoDataList)
            {
                PhotoModel PVM = new PhotoModel()
                {
                    PhotoName = item.PhotoName,
                    PhotoSrc = item.PhotoSrc,
                    PhotoId = item.PhotoId,
                    TripId = item.TripId
                };
                
                CTVM.PhotoData.Add(PVM);
            }

            CTVM.VideoData = new List<VideoModel>();

            var videoDataList = (from Videos in db.Videos
                where Videos.TripId == id
                select new { Videos.VideoName, Videos.VideoSrc, Videos.VideoId, Videos.TripId }).ToList();

            foreach (var item in videoDataList)
            {
                VideoModel PVM = new VideoModel()
                {
                    VideoName = item.VideoName,
                    VideoSrc = item.VideoSrc,
                    VideoId = item.VideoId,
                    TripId = item.TripId
                };

                CTVM.VideoData.Add(PVM);
            }

            return View(CTVM); 
        }
    }
}