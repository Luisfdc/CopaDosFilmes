using CopaDosFilmes.Dominios;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CopaDosFilmesTeste
{
    public class PrimeiraFaseTeste
    {
        private Filme[] _filmes;

        public PrimeiraFaseTeste()
        {
            var filmesJson = @"[{""id"":""tt3606756"",""titulo"":""Os Incríveis 2"",""ano"":2018,""nota"":8.5},{""id"":""tt4881806"",""titulo"":""Jurassic World: Reino Ameaçado"",""ano"":2018,""nota"":6.7},{""id"":""tt5164214"",""titulo"":""Oito Mulheres e um Segredo"",""ano"":2018,""nota"":6.3},{""id"":""tt7784604"",""titulo"":""Hereditário"",""ano"":2018,""nota"":7.8},{""id"":""tt4154756"",""titulo"":""Vingadores: Guerra Infinita"",""ano"":2018,""nota"":8.8},{""id"":""tt5463162"",""titulo"":""Deadpool 2"",""ano"":2018,""nota"":8.1},{""id"":""tt3778644"",""titulo"":""Han Solo: Uma História Star Wars"",""ano"":2018,""nota"":7.2},{""id"":""tt3501632"",""titulo"":""Thor: Ragnarok"",""ano"":2017,""nota"":7.9},{""id"":""tt2854926"",""titulo"":""Te Peguei!"",""ano"":2018,""nota"":7.1},{""id"":""tt0317705"",""titulo"":""Os Incríveis"",""ano"":2004,""nota"":8.0},{""id"":""tt3799232"",""titulo"":""A Barraca do Beijo"",""ano"":2018,""nota"":6.4},{""id"":""tt1365519"",""titulo"":""Tomb Raider: A Origem"",""ano"":2018,""nota"":6.5},{""id"":""tt1825683"",""titulo"":""Pantera Negra"",""ano"":2018,""nota"":7.5},{""id"":""tt5834262"",""titulo"":""Hotel Artemis"",""ano"":2018,""nota"":6.3},{""id"":""tt7690670"",""titulo"":""Superfly"",""ano"":2018,""nota"":5.1},{""id"":""tt6499752"",""titulo"":""Upgrade"",""ano"":2018,""nota"":7.8}]";

            _filmes = JsonConvert.DeserializeObject<List<Filme>>(filmesJson).ToArray();

        }

        [Fact]
        public void Verificar_se_retorna_semi_final_recebendo_oito_filmes()
        {
            var primeiraFase = new PrimeiraFase
            {
                Filmes = _filmes.ToList().GetRange(0,8)
            };

            var semiFinal = primeiraFase.Iniciar();

            Assert.NotNull(semiFinal);
        }

        [Fact]
        public void Verificar_se_retorna_erro_se_nao_receber_todos_os_times()
        {
            var primeiraFase = new PrimeiraFase
            {
                Filmes = _filmes.ToList().GetRange(0, 4)
            };

            Assert.Throws<ArgumentOutOfRangeException>(() => primeiraFase.Iniciar());
        }


        [Fact]
        public void Verificar_se_retorna_erro_se_nao_receber_nenhum_filme()
        {
            var primeiraFase = new PrimeiraFase();

            Assert.Throws<NullReferenceException>(() => primeiraFase.Iniciar());
        }

        [Fact]
        public void Verificar_se_retorna_filmes_corretos_na_semi_final_recebendo_oito_filmes()
        {
            var filmes = _filmes.ToList();
            var primeiraFase = new PrimeiraFase
            {
                Filmes = new List<Filme>{
                    filmes.FirstOrDefault(x => x.Titulo == "Deadpool 2"),
                    filmes.FirstOrDefault(x => x.Titulo == "Han Solo: Uma História Star Wars"),
                    filmes.FirstOrDefault(x => x.Titulo == "Hereditário"),
                    filmes.FirstOrDefault(x => x.Titulo == "Jurassic World: Reino Ameaçado"),
                    filmes.FirstOrDefault(x => x.Titulo == "Oito Mulheres e um Segredo"),
                    filmes.FirstOrDefault(x => x.Titulo == "Os Incríveis 2"),
                    filmes.FirstOrDefault(x => x.Titulo == "Thor: Ragnarok"),
                    filmes.FirstOrDefault(x => x.Titulo == "Vingadores: Guerra Infinita")
                }
            };

            var semiFinal = primeiraFase.Iniciar();

            var filme1 = semiFinal.Filmes[0].Titulo == "Vingadores: Guerra Infinita";
            var filme2 = semiFinal.Filmes[1].Titulo == "Thor: Ragnarok";
            var filme3 = semiFinal.Filmes[2].Titulo == "Os Incríveis 2";
            var filme4 = semiFinal.Filmes[3].Titulo == "Jurassic World: Reino Ameaçado";

            Assert.True(filme1 && filme2 && filme3 && filme4);
        }
        
    }
}
