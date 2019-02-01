using CopaDosFilmes.Dominios;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CopaDosFilmesTeste
{
    public class FinalTeste
    {
        private Filme[] _filmes;

        public FinalTeste()
        {
            var filmesJson = @"[{""id"":""tt3606756"",""titulo"":""Os Incríveis 2"",""ano"":2018,""nota"":8.5},{""id"":""tt4881806"",""titulo"":""Jurassic World: Reino Ameaçado"",""ano"":2018,""nota"":6.7},{""id"":""tt5164214"",""titulo"":""Oito Mulheres e um Segredo"",""ano"":2018,""nota"":6.3},{""id"":""tt7784604"",""titulo"":""Hereditário"",""ano"":2018,""nota"":7.8},{""id"":""tt4154756"",""titulo"":""Vingadores: Guerra Infinita"",""ano"":2018,""nota"":8.8},{""id"":""tt5463162"",""titulo"":""Deadpool 2"",""ano"":2018,""nota"":8.1},{""id"":""tt3778644"",""titulo"":""Han Solo: Uma História Star Wars"",""ano"":2018,""nota"":7.2},{""id"":""tt3501632"",""titulo"":""Thor: Ragnarok"",""ano"":2017,""nota"":7.9},{""id"":""tt2854926"",""titulo"":""Te Peguei!"",""ano"":2018,""nota"":7.1},{""id"":""tt0317705"",""titulo"":""Os Incríveis"",""ano"":2004,""nota"":8.0},{""id"":""tt3799232"",""titulo"":""A Barraca do Beijo"",""ano"":2018,""nota"":6.4},{""id"":""tt1365519"",""titulo"":""Tomb Raider: A Origem"",""ano"":2018,""nota"":6.5},{""id"":""tt1825683"",""titulo"":""Pantera Negra"",""ano"":2018,""nota"":7.5},{""id"":""tt5834262"",""titulo"":""Hotel Artemis"",""ano"":2018,""nota"":6.3},{""id"":""tt7690670"",""titulo"":""Superfly"",""ano"":2018,""nota"":5.1},{""id"":""tt6499752"",""titulo"":""Upgrade"",""ano"":2018,""nota"":7.8}]";

            _filmes = JsonConvert.DeserializeObject<List<Filme>>(filmesJson).ToArray();

        }

        [Fact]
        public void Verificar_se_retorna_campeao_recebendo_dois_filmes()
        {
            var final = new Final
            {
                Filmes = _filmes.ToList().GetRange(0, 2)
            };

            var campeao = final.Iniciar();

            Assert.NotNull(campeao);
        }

        [Fact]
        public void Verificar_se_retorna_erro_se_nao_receber_todos_os_times()
        {
            var final = new Final
            {
                Filmes = new List<Filme> { _filmes[0] }
            };

            Assert.Throws<ArgumentOutOfRangeException>(() => final.Iniciar());
        }


        [Fact]
        public void Verificar_se_retorna_erro_se_nao_receber_nenhum_filme()
        {
            var final = new Final();

            Assert.Throws<NullReferenceException>(() => final.Iniciar());
        }

        [Fact]
        public void Verificar_se_retorna_filme_campeao_correto_recebendo_dois_filmes()
        {
            var filmes = _filmes.ToList();
            var Final = new Final
            {
                Filmes = new List<Filme>{
                    filmes.FirstOrDefault(x => x.Titulo == "Vingadores: Guerra Infinita"),
                    filmes.FirstOrDefault(x => x.Titulo == "Os Incríveis 2")
                }
            };

            var campeao = Final.Iniciar();

            Assert.True(campeao.Titulo == "Vingadores: Guerra Infinita");
        }

    }
}
