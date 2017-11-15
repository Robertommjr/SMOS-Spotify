using Balanca.Application.ViewModel;
using Balanca.Servico;
using SMOS.Domain.Models;
using SMOS.Infra.Repositorio;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SMOS.Application.Controllers
{
    public class ProfileController : Controller
    {
        private readonly SpotifyAuthViewModel _spotifyAuthViewModel;
        private readonly ISpotifyApi _spotifyApi;

        public ProfileController(SpotifyAuthViewModel spotifyAuthViewModel, ISpotifyApi spotifyApi)
        {
            _spotifyAuthViewModel = spotifyAuthViewModel;
            _spotifyApi = spotifyApi;
        }


        public ActionResult Index(string access_token, string error)
        {
            if (error != null || error == "access_denied")
                return View("Error");

            if (string.IsNullOrEmpty(access_token))
                return View();

            try
            {
                _spotifyApi.Token = access_token;
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

                return RedirectToAction("Index", "Home", new {token = access_token });
            }
            catch (Exception)
            {
                return View("Error");
            }

        }
    }
}