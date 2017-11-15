using System.Web.Mvc;

namespace SMOS.Application.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index(string token)
        {
            //Se a sessão não tiver Token ou for nulo
            if((string)Session["Token"] == null)
                Session["Token"] = token;

            return View();
        }

        public ActionResult Welcome()
        {
            return View("~/Views/Home/Welcome.cshtml");
        }
          
        public ActionResult Playlist()
        {
            return View("~/Views/Home/Playlist.cshtml");
        }

        public ActionResult SortPlayList()
        {
            return View("~/Views/Home/SortPlayList.cshtml");
        }

        public ActionResult Tracks()
        {
            return View("~/Views/Home/Tracks.cshtml");
        }

    }
}