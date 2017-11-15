﻿using Newtonsoft.Json;
using SMOS.Infra.Repositorio;
using System;
using System.IO;
using System.Net;

namespace SMOS.Servico.Api
{
    public class SpotifyApi : ISpotifyApi
    {
        public string Token { get; set; }

        public SpotifyApi()
        {

        }

        public SpotifyApi(string token)
        {
            Token = token;
        }

        public T GetSpotifyType<T>(string url)
        {
            try
            {
                WebRequest request = WebRequest.Create(url);
                request.Method = "GET";
                request.Headers.Set("Authorization", "Bearer" + " " + Token);
                request.ContentType = "application/json; charset=utf-8";

                T type = default(T);

                using (WebResponse response = request.GetResponse())
                {
                    using (Stream dataStream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(dataStream))
                        {
                            string responseFromServer = reader.ReadToEnd();
                            type = JsonConvert.DeserializeObject<T>(responseFromServer);
                        }
                    }
                }
                return type;
            }
            catch (WebException ex)
            {
                return default(T);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
