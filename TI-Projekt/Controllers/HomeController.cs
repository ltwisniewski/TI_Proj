using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using TI_Projekt.ViewModel;

namespace TI_Projekt.Controllers
{
    public class HomeController : Controller
    {
        private TripDbContext db = new TripDbContext(); 

        public ActionResult Index()
        {

            List<DisplayShortTripViewModel> DSTVM = new List<DisplayShortTripViewModel>(); 

            var tripList = (from Trips in db.Trips

                select new { Trips.TripId, Trips.Title, Trips.StartDate, Trips.StartPlace, Trips.IsDeleted}).ToList();

            foreach (var item in tripList)

            {

                DisplayShortTripViewModel objcvm = new DisplayShortTripViewModel();

                objcvm.TripId = item.TripId;

                objcvm.Title = item.Title;
                objcvm.StartDate = item.StartDate;
                objcvm.StartPlace = item.StartPlace;
                objcvm.IsDeleted = item.IsDeleted;

                DSTVM.Add(objcvm);

            }

            return View(DSTVM);
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            if (Id != 0)
            {
                string CS = ConfigurationManager.ConnectionStrings["TI"].ConnectionString;
                string VideoName;
                int videoId;

                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("select VideoName, VideoId from Videos where TripId = @Id",
                            con)
                        { CommandType = CommandType.Text };
                    con.Open();
                    cmd.Parameters.AddWithValue("@Id", Id);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        VideoName = rdr["VideoName"].ToString();
                        
                        FileInfo fi = new FileInfo(Server.MapPath("~/Content/Videos/" + VideoName));
                        fi.Delete();

                        Int32.TryParse(rdr["VideoId"].ToString(), out videoId);

                        using (SqlConnection con2 = new SqlConnection(CS))
                        {
                            SqlCommand cmd2 = new SqlCommand("delete from Videos where VideoId = @VideoId", con)
                            {
                                CommandType = CommandType.Text
                            };

                            cmd2.Parameters.AddWithValue("@VideoId", videoId);
                            cmd2.ExecuteNonQuery();
                            con2.Close();
                        }
                    }
                    con.Close();
                }

                string PhotoName;
                int photoId;

                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("select PhotoName, PhotoId from Photos where TripId = @Id",
                            con)
                        { CommandType = CommandType.Text };
                    con.Open();
                    cmd.Parameters.AddWithValue("@Id", Id);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        PhotoName = rdr["PhotoName"].ToString();
                        FileInfo fi = new FileInfo(Server.MapPath("~/Content/Photos/" + PhotoName));
                        fi.Delete();

                        Int32.TryParse(rdr["PhotoId"].ToString(), out photoId);

                        using (SqlConnection con2 = new SqlConnection(CS))
                        {
                            SqlCommand cmd2 = new SqlCommand("delete from Photos where PhotoId = @PhotoId", con)
                            {
                                CommandType = CommandType.Text
                            };

                            con2.Open();
                            cmd2.Parameters.AddWithValue("@PhotoId", photoId);
                            cmd2.ExecuteNonQuery();
                            con2.Close();
                        }
                    }
                    con.Close();
                }

                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("delete from Trips where TripId = @Id",
                            con)
                        { CommandType = CommandType.Text };
                    con.Open();
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

            }

            return RedirectToAction("index", "Home");
        }
    }
}