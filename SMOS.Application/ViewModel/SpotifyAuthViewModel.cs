using Balanca.Domain.Enums;
using SMOS.Util;

namespace Balanca.Application.ViewModel
{
    public class SpotifyAuthViewModel
    {
        private string _clientId;
        private string _redirectUri;
        private string _state;
        private Scope _scope;

        public SpotifyAuthViewModel(string clientId, string redirectUri, string state, Scope scope)
        {
            _clientId = clientId;
            _redirectUri = redirectUri;
            _state = state;
            _scope = scope;
        }

        public object GetAuthUri()
        {
            return "https://accounts.spotify.com/en/authorize?client_id=" + _clientId +
                "&response_type=token&redirect_uri=" + _redirectUri +
                "&state=&scope=" + _scope.GetStringAttribute(" ") +
                "&show_dialog=true";
        }
    }
}