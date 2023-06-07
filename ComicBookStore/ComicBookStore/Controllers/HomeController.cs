using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComicBookStore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Location()
        {
            string markers = "[";
            string conString = "Data Source=DESKTOP-32I3APT;Initial Catalog=ComicStoreLocations;Integrated Security=True;";
            SqlCommand cmd = new SqlCommand("SELECT * FROM Geolocations");
            using (SqlConnection con = new SqlConnection(conString))
            {
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        markers += "{";
                        markers += string.Format("'title': '{0}',", sdr["Name"]);
                        markers += string.Format("'lat': '{0}',", sdr["Latitude"]);
                        markers += string.Format("'lng': '{0}',", sdr["Longitude"]);
                        markers += "},";
                    }
                }
                con.Close();
            }

            markers += "];";
            ViewBag.Markers = markers;
            return View();
        }
        public ActionResult Favorites()
        {
            return View();
        }
        

        public ActionResult About()
        {
            return View();
        }

        public ActionResult LatestNews()
        {
            WebRequest wReq = WebRequest.Create("https://www.marvel.com/comics?byZone=marvel_site_zone&options[offset]=12&offset=0&options[limit]=12&options[formatType]=issue&options[noVariants]=true&options[dateDescriptor]=thisWeek&options[orderBy][0]=issues.onsale_date+DESC&options[orderBy][1]=issues.id+DESC&contentType=comic_issue&method=fetchByReleaseDate&options%5Boffset%5D=0&totalcount=12");
            WebResponse mRes = wReq.GetResponse();
            StreamReader sr = new StreamReader(mRes.GetResponseStream());
            string sHTML = sr.ReadToEnd();
            sr.Close();
            mRes.Close();

            if (sHTML != string.Empty && sHTML != null)
            {
                Response.Write(sHTML);
            }
            return View();
        }
    }
}