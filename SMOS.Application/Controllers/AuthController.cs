using Balanca.Application.ViewModel;
using SMOS.Infra.Repositorio;
using System.Web.Mvc;

namespace Balanca.Application.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {

        private readonly SpotifyAuthViewModel _spotifyAuthViewModel;
        private readonly ISpotifyApi _spotifyApi;

        public AuthController(SpotifyAuthViewModel spotifyAuthViewModel, ISpotifyApi spotifyApi)
        {
            _spotifyAuthViewModel = spotifyAuthViewModel;
            _spotifyApi = spotifyApi;
        }


        // GET: Auth
        public ActionResult LogIn()
        {
            ViewBag.AuthUri = _spotifyAuthViewModel.GetAuthUri();

            return View("~/Views/Auth/LogIn.cshtml");
        }

        public ActionResult AuthResponse()
        {
            ViewBag.AuthUri = _spotifyAuthViewModel.GetAuthUri();

            return View();
        }

        public JsonResult ValidaToken()
        {
            var data = false;
            if ((string)Session["Token"] != null)
                data = true;

            return Json(data, JsonRequestBehavior.AllowGet);
        }


    }
    
}