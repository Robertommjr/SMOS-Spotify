using Balanca.Application.ViewModel;
using Balanca.Servico;
using SMOS.Domain.Models;
using SMOS.Infra.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMOS.Application.Controllers
{
    public class TracksController : Controller
    {
        // GET: Tracks
        public ActionResult Index()
        {
            return View();
        }

        private readonly SpotifyAuthViewModel _spotifyAuthViewModel;
        private readonly ISpotifyApi _spotifyApi;

        public TracksController(SpotifyAuthViewModel spotifyAuthViewModel, ISpotifyApi spotifyApi)
        {
            _spotifyAuthViewModel = spotifyAuthViewModel;
            _spotifyApi = spotifyApi;
        }

        public JsonResult getTracks()
        {
            //Se não houver sessão ativa, redireciona para o login
            if ((string)Session["Token"] == null)
                return Json(false, JsonRequestBehavior.AllowGet);
            else
            {
                try
                {
                    _spotifyApi.Token = (string)Session["Token"];
                    SpotifyService spotifyService = new SpotifyService(_spotifyApi);

                    SpotifyUser spotifyUser = spotifyService.GetUserProfile();

                    //Get user playlists ids
                    Playlists playlists = spotifyService.GetPlaylists(spotifyUser.UserId);

                    //Get all tracks from user
                    List<string> tracks = spotifyService.GetTracksAndArtistsFromPlaylists(playlists);

                    return Json(tracks, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {

                    return Json(false, JsonRequestBehavior.AllowGet);
                }
            }
        }
    }
}