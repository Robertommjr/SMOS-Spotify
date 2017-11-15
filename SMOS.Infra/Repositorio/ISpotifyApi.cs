namespace SMOS.Infra.Repositorio
{
    public interface ISpotifyApi
    {
        string Token { get; set; }

        T GetSpotifyType<T>(string url);
    }
}
