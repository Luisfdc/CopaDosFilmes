using CopaDosFilmes.Dominios;
using CopaDosFimes.Repositorio.Interface;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CopaDosFimes.Repositorio
{
    public class CopaDosFilmesRepositorio : ICopaDosFilmesRepositorio
    {

        public IEnumerable<Filme> ListarFilmes()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"https://copadosfilmes.azurewebsites.net/");
                var response = client.GetAsync("api/filmes").Result;
                var json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                var filmes = JsonConvert.DeserializeObject<List<Filme>>(json);
                return filmes.ToList();
            }
        }

    }
}
