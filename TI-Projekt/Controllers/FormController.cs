using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TI_Projekt.Models;
using TI_Projekt.ViewModel;

namespace TI_Projekt.Controllers
{
    public class FormController : Controller
    {
        [HttpGet]
        public ActionResult AddInfo()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddExtInfo(int Id)
        {
            AddTripViewModel trip = new AddTripViewModel();
            string CS = ConfigurationManager.ConnectionStrings["TI"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd =
                    new SqlCommand(
                        "select Title,StartDate,EndDate,StartPlace,DestinationPlace,Distance from Trips where TripId = @Id",
                        con) {CommandType = CommandType.Text};
                con.Open();
                cmd.Parameters.AddWithValue("@Id", Id);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    trip.Title = rdr["Title"].ToString();
                    trip.StartDate = DateTime.Parse(rdr["StartDate"].ToString()).Date;
                    trip.EndDate = DateTime.Parse(rdr["EndDate"].ToString()).Date;
                    trip.StartPlace = rdr["StartPlace"].ToString();
                    trip.DestinationPlace = rdr["DestinationPlace"].ToString();
                    trip.Distance = Convert.ToInt32(rdr["Distance"]);
                }
            }

            return View(trip);
        }

        [HttpPost]
        public ActionResult AddInfo(AddTripViewModel atvm)
        {
            int Id = 0;
            DateTime StartDate;
            DateTime EndDate;
            string Title;
            string StartPlace;
            string DestinationPlace;
            double Distance;
            DateTime CreatedOn = DateTime.Now;


            if (atvm != null)
            {
                if (atvm.Title == null)
                {
                    Title = "default";
                }
                else
                {
                    Title = atvm.Title;
                }

                if (atvm.StartDate.Equals("01.01.0001 00:00:00"))
                {
                    StartDate = DateTime.Now;
                }
                else
                {
                    StartDate = atvm.StartDate;
                }

                if (atvm.EndDate.Equals("01.01.0001 00:00:00"))
                {
                    EndDate = DateTime.Now;
                }
                else
                {
                    EndDate = atvm.EndDate;
                }

                if (atvm.StartPlace == null)
                {
                    StartPlace = "default";
                }
                else
                {
                    StartPlace = atvm.StartPlace;
                }

                if (atvm.DestinationPlace == null)
                {
                    DestinationPlace = "default";
                }
                else
                {
                    DestinationPlace = atvm.DestinationPlace;
                }

                if (atvm.Distance == 0)
                {
                    Distance = 1;
                }
                else
                {
                    Distance = atvm.Distance;
                }


                string CS = ConfigurationManager.ConnectionStrings["TI"].ConnectionString;

                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand(
                        "insert into Trips (Title,StartDate,EndDate,StartPlace,DestinationPlace,Distance,IsDeleted,CreatedOn) " +
                        "values (@Title,@StartDate,@EndDate,@StartPlace,@DestinationPlace,@Distance,1,@CreatedOn)",
                        con) {CommandType = CommandType.Text};

                    con.Open();
                    cmd.Parameters.AddWithValue("@Title", Title);
                    cmd.Parameters.AddWithValue("@StartDate", StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", EndDate);
                    cmd.Parameters.AddWithValue("@StartPlace", StartPlace);
                    cmd.Parameters.AddWithValue("@DestinationPlace", DestinationPlace);
                    cmd.Parameters.AddWithValue("@Distance", Distance);
                    cmd.Parameters.AddWithValue("@CreatedOn", CreatedOn);

                    cmd.ExecuteNonQuery();
                }

                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd =
                        new SqlCommand("select TripId from Trips where Title = @Title and CreatedOn = @CreatedOn", con)
                        {
                            CommandType = CommandType.Text
                        };

                    con.Open();
                    cmd.Parameters.AddWithValue("@Title", Title);
                    cmd.Parameters.AddWithValue("@CreatedOn", CreatedOn);

                    SqlDataReader dr;
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        int.TryParse(dr["TripId"].ToString(), out Id);
                    }
                }
                return RedirectToAction("AddVideo", "Form", new { Id });
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }



        [HttpPost]
        public ActionResult AddExtInfo(AddTripViewModel atvm, int Id)
        {
            DateTime StartDate;
            DateTime EndDate;
            string Title;
            string StartPlace;
            string DestinationPlace;
            double Distance;
            DateTime CreatedOn = DateTime.Now;


            if (atvm != null)
            {
                if (atvm.Title == null)
                {
                    Title = "default";
                }
                else
                {
                    Title = atvm.Title;
                }
                if (atvm.StartDate.Equals("01.01.0001 00:00:00"))
                {
                    StartDate = DateTime.Now;
                }
                else
                {
                    StartDate = atvm.StartDate;
                }
                if (atvm.EndDate.Equals("01.01.0001 00:00:00"))
                {
                    EndDate = DateTime.Now;
                }
                else
                {
                    EndDate = atvm.EndDate;
                }

                if (atvm.StartPlace == null)
                {
                    StartPlace = "default";
                }
                else
                {
                    StartPlace = atvm.StartPlace;
                }

                if (atvm.DestinationPlace == null)
                {
                    DestinationPlace = "default";
                }
                else
                {
                    DestinationPlace = atvm.DestinationPlace;
                }

                if (atvm.Distance == 0)
                {
                    Distance = 1;
                }
                else
                {
                    Distance = atvm.Distance;
                }
                

                string CS = ConfigurationManager.ConnectionStrings["TI"].ConnectionString;


                   
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        SqlCommand cmd = new SqlCommand(
                            "update Trips set Title=@Title,StartDate=@StartDate,EndDate=@EndDate,StartPlace=@StartPlace,DestinationPlace=@DestinationPlace,Distance=@Distance" +
                            " where TripId=@Id", con) {CommandType = CommandType.Text};

                        con.Open();
                        cmd.Parameters.AddWithValue("@Title", Title);
                        cmd.Parameters.AddWithValue("@StartDate", StartDate);
                        cmd.Parameters.AddWithValue("@EndDate", EndDate);
                        cmd.Parameters.AddWithValue("@StartPlace", StartPlace);
                        cmd.Parameters.AddWithValue("@DestinationPlace", DestinationPlace);
                        cmd.Parameters.AddWithValue("@Distance", Distance);
                        cmd.Parameters.AddWithValue("@CreatedOn", CreatedOn);
                        cmd.Parameters.AddWithValue("@Id", Id);

                        cmd.ExecuteNonQuery();
                    }

                    return RedirectToAction("AddVideo", "Form", new { Id });
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        

        [HttpGet]
        public ActionResult AddVideo(int Id)
        {
            if (Id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                List<VideoModel> videolist = new List<VideoModel>();
                string CS = ConfigurationManager.ConnectionStrings["TI"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("select VideoId,VideoName,VideoSrc from Videos where TripId = @Id",
                        con) {CommandType = CommandType.Text};
                    con.Open();
                    cmd.Parameters.AddWithValue("@Id", Id);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        VideoModel video = new VideoModel
                        {
                            VideoId = Convert.ToInt32(rdr["VideoId"]),
                            VideoName = rdr["VideoName"].ToString(),
                            VideoSrc = rdr["VideoSrc"].ToString()
                        };

                        videolist.Add(video);
                    }
                }

                return View(videolist);
            }

        }

        [HttpPost]
        public ActionResult AddVideo(HttpPostedFileBase fileupload, string id)
        {
            if (fileupload != null & id != "0")
            {
                string fileName = id+"_"+Path.GetFileName(fileupload.FileName);
                fileupload.SaveAs(Server.MapPath("~/Content/Videos/" + fileName));

                string CS = ConfigurationManager.ConnectionStrings["TI"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd =
                        new SqlCommand("insert into Videos (VideoName,VideoSrc,TripId) values (@Name,@FilePath,@Id)",
                            con) {CommandType = CommandType.Text};

                    con.Open();
                    cmd.Parameters.AddWithValue("@Name", fileName);
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("FilePath", "~/Content/Videos/" + fileName);
                    cmd.ExecuteNonQuery();
                }
            }

            return RedirectToAction("AddVideo", "Form", new {id});
        }

        [HttpPost]
        public ActionResult RemoveVideo(int videoId, string Id)
        {
            if (videoId != 0)
            {
                string CS = ConfigurationManager.ConnectionStrings["TI"].ConnectionString;
                string VideoName;

                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("select VideoName from Videos where VideoId = @Id",
                        con) {CommandType = CommandType.Text};
                    con.Open();
                    cmd.Parameters.AddWithValue("@Id", videoId);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        VideoName = rdr["VideoName"].ToString();
                        FileInfo fi = new FileInfo(Server.MapPath("~/Content/Videos/" + VideoName));
                        fi.Delete();
                    }
                }

                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("delete from Videos where VideoId = @Id", con)
                    {
                        CommandType = CommandType.Text
                    };

                    con.Open();
                    cmd.Parameters.AddWithValue("@Id", videoId);
                    cmd.ExecuteNonQuery();
                }

                
            }

            return RedirectToAction("AddVideo", "Form", new {Id});
        }



        [HttpGet]
        public ActionResult AddPhoto(int Id)
        {
            if (Id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                List<PhotoModel> photolist = new List<PhotoModel>();
                string CS = ConfigurationManager.ConnectionStrings["TI"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("select PhotoId,PhotoName,PhotoSrc from Photos where TripId = @Id",
                        con)
                    { CommandType = CommandType.Text };
                    con.Open();
                    cmd.Parameters.AddWithValue("@Id", Id);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        PhotoModel photo = new PhotoModel()
                        {
                            PhotoId = Convert.ToInt32(rdr["PhotoId"]),
                            PhotoName = rdr["PhotoName"].ToString(),
                            PhotoSrc = rdr["PhotoSrc"].ToString()
                        };

                        photolist.Add(photo);
                    }
                }

                return View(photolist);
            }

        }

        [HttpPost]
        public ActionResult AddPhoto(HttpPostedFileBase fileupload, string id)
        {
            if (fileupload != null & id != "0")
            {
                Random r = new Random();
                string num = r.Next(1000).ToString();
                string fileName = id + "_" + num + "_" + Path.GetFileName(fileupload.FileName);
                fileupload.SaveAs(Server.MapPath("~/Content/Photos/" + fileName));

                string CS = ConfigurationManager.ConnectionStrings["TI"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd =
                        new SqlCommand("insert into Photos (PhotoName,PhotoSrc,TripId) values (@Name,@FilePath,@Id)",
                            con)
                        { CommandType = CommandType.Text };

                    con.Open();
                    cmd.Parameters.AddWithValue("@Name", fileName);
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("FilePath", "~/Content/Photos/" + fileName);
                    cmd.ExecuteNonQuery();
                }
            }

            return RedirectToAction("AddPhoto", "Form", new { id });
        }

        [HttpPost]
        public ActionResult RemovePhoto(int photoId, string Id)
        {
            if (photoId != 0)
            {
                string CS = ConfigurationManager.ConnectionStrings["TI"].ConnectionString;
                string PhotoName;

                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("select PhotoName from Photos where PhotoId = @Id",
                            con)
                        { CommandType = CommandType.Text };
                    con.Open();
                    cmd.Parameters.AddWithValue("@Id", photoId);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        PhotoName = rdr["PhotoName"].ToString();
                        FileInfo fi = new FileInfo(Server.MapPath("~/Content/Photos/" + PhotoName));
                        fi.Delete();
                    }
                }

                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("delete from Photos where PhotoId = @Id", con)
                    {
                        CommandType = CommandType.Text
                    };

                    con.Open();
                    cmd.Parameters.AddWithValue("@Id", photoId);
                    cmd.ExecuteNonQuery();
                }


            }

            return RedirectToAction("AddPhoto", "Form", new { Id });
        }

        [HttpPost]
        public ActionResult Finish(int Id)
        {
            string CS = ConfigurationManager.ConnectionStrings["TI"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand(
                        "update Trips set IsDeleted=0 where TripId=@Id", con)
                    { CommandType = CommandType.Text };

                con.Open();
                cmd.Parameters.AddWithValue("@Id", Id);

                cmd.ExecuteNonQuery();
            }

            return RedirectToAction("Index", "Home", new { Id });
        }
    }
}