using Balanca.Application.ViewModel;
using Balanca.Servico;
using SMOS.Domain.Models;
using SMOS.Infra.Repositorio;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SMOS.Application.Controllers
{
    public class SortPlayListController : Controller
    {
        private readonly SpotifyAuthViewModel _spotifyAuthViewModel;
        private readonly ISpotifyApi _spotifyApi;

        public SortPlayListController(SpotifyAuthViewModel spotifyAuthViewModel, ISpotifyApi spotifyApi)
        {
            _spotifyAuthViewModel = spotifyAuthViewModel;
            _spotifyApi = spotifyApi;
        }

        // GET: SortPlayList
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult getPlayList() {
            //Se não houver sessão ativa, redireciona para o login
            if ((string)Session["Token"] == null)
                return Json(false, JsonRequestBehavior.AllowGet);
            else {
                try {
                    _spotifyApi.Token = (string)Session["Token"];
                    SpotifyService spotifyService = new SpotifyService(_spotifyApi);

                    //Get user_id and user displayName
                    SpotifyUser spotifyUser = spotifyService.GetUserProfile();
                    ViewBag.UserName = spotifyUser.DisplayName;

                    //Get user playlists ids
                    Playlists playlists = spotifyService.GetPlaylists(spotifyUser.UserId);

                    //Get all tracks from user
                    List<string> tracks = spotifyService.GetTracksAndArtistsFromPlaylists(playlists);

                    //Generate the new playlist 
                    List<string> newPlayList = spotifyService.GenerateNewPlaylist(spotifyUser.DisplayName, tracks);

                    return Json(newPlayList, JsonRequestBehavior.AllowGet);
                } catch (Exception ex) {

                    return Json(false, JsonRequestBehavior.AllowGet);
                }
            }
        }
    }
}