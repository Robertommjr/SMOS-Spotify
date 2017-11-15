using Balanca.Application.ViewModel;
using Balanca.Servico;
using SMOS.Domain.Models;
using SMOS.Infra.Repositorio;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SMOS.Application.Controllers
{
    public class PlayListController : Controller
    {
        private readonly SpotifyAuthViewModel _spotifyAuthViewModel;
        private readonly ISpotifyApi _spotifyApi;

        public PlayListController(SpotifyAuthViewModel spotifyAuthViewModel, ISpotifyApi spotifyApi)
        {
            _spotifyAuthViewModel = spotifyAuthViewModel;
            _spotifyApi = spotifyApi;
        }

        // GET: PlayList
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getPlayList()
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

                    //Get user_id and user displayName
                    SpotifyUser spotifyUser = spotifyService.GetUserProfile();
                    ViewBag.UserName = spotifyUser.DisplayName;

                    //Get user playlists ids
                    Playlists playlists = spotifyService.GetPlaylists(spotifyUser.UserId);


                    return Json(playlists, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
            }
        }
    }
}