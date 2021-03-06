using NUnit.Framework;
using CopaDosFilmes.Dominios;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DominioTest
{
    public class DominioTest
    {
        private Filme[] _filmes;

        public DominioTest()
        {
            var filmesJson = @"[{""id"":""tt3606756"",""titulo"":""Os Incr�veis 2"",""ano"":2018,""nota"":8.5},{""id"":""tt4881806"",""titulo"":""Jurassic World: Reino Amea�ado"",""ano"":2018,""nota"":6.7},{""id"":""tt5164214"",""titulo"":""Oito Mulheres e um Segredo"",""ano"":2018,""nota"":6.3},{""id"":""tt7784604"",""titulo"":""Heredit�rio"",""ano"":2018,""nota"":7.8},{""id"":""tt4154756"",""titulo"":""Vingadores: Guerra Infinita"",""ano"":2018,""nota"":8.8},{""id"":""tt5463162"",""titulo"":""Deadpool 2"",""ano"":2018,""nota"":8.1},{""id"":""tt3778644"",""titulo"":""Han Solo: Uma Hist�ria Star Wars"",""ano"":2018,""nota"":7.2},{""id"":""tt3501632"",""titulo"":""Thor: Ragnarok"",""ano"":2017,""nota"":7.9},{""id"":""tt2854926"",""titulo"":""Te Peguei!"",""ano"":2018,""nota"":7.1},{""id"":""tt0317705"",""titulo"":""Os Incr�veis"",""ano"":2004,""nota"":8.0},{""id"":""tt3799232"",""titulo"":""A Barraca do Beijo"",""ano"":2018,""nota"":6.4},{""id"":""tt1365519"",""titulo"":""Tomb Raider: A Origem"",""ano"":2018,""nota"":6.5},{""id"":""tt1825683"",""titulo"":""Pantera Negra"",""ano"":2018,""nota"":7.5},{""id"":""tt5834262"",""titulo"":""Hotel Artemis"",""ano"":2018,""nota"":6.3},{""id"":""tt7690670"",""titulo"":""Superfly"",""ano"":2018,""nota"":5.1},{""id"":""tt6499752"",""titulo"":""Upgrade"",""ano"":2018,""nota"":7.8}]";

            _filmes = JsonConvert.DeserializeObject<List<Filme>>(filmesJson).ToArray();
            
        }
        
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Verificar_se_retorna_semi_final_recebendo_oito_filmes()
        {
            var primeiraFase = new PrimeiraFase
            {
                FilmeUm = _filmes[0],
                FilmeDois = _filmes[1],
                FilmeTres = _filmes[2],
                FilmeQuatro = _filmes[3],
                FilmeCinco = _filmes[4],
                FilmeSeis = _filmes[5],
                FilmeSete = _filmes[6],
                FilmeOito = _filmes[7],
            };

            var semiFinal = primeiraFase.Inciar();

            Assert.IsNotNull(semiFinal);
        }
    }
}