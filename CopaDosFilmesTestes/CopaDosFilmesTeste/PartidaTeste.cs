using CopaDosFilmes.Dominios;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CopaDosFilmesTeste
{
    public class PartidaTeste
    {
        private Filme[] _filmes;

        public PartidaTeste()
        {
            var filmesJson = @"[{""id"":""tt3606756"",""titulo"":""Os Incr�veis 2"",""ano"":2018,""nota"":8.5},{""id"":""tt4881806"",""titulo"":""Jurassic World: Reino Amea�ado"",""ano"":2018,""nota"":6.7},{""id"":""tt5164214"",""titulo"":""Oito Mulheres e um Segredo"",""ano"":2018,""nota"":6.3},{""id"":""tt7784604"",""titulo"":""Heredit�rio"",""ano"":2018,""nota"":7.8},{""id"":""tt4154756"",""titulo"":""Vingadores: Guerra Infinita"",""ano"":2018,""nota"":8.8},{""id"":""tt5463162"",""titulo"":""Deadpool 2"",""ano"":2018,""nota"":8.1},{""id"":""tt3778644"",""titulo"":""Han Solo: Uma Hist�ria Star Wars"",""ano"":2018,""nota"":7.2},{""id"":""tt3501632"",""titulo"":""Thor: Ragnarok"",""ano"":2017,""nota"":7.9},{""id"":""tt2854926"",""titulo"":""Te Peguei!"",""ano"":2018,""nota"":7.1},{""id"":""tt0317705"",""titulo"":""Os Incr�veis"",""ano"":2004,""nota"":8.0},{""id"":""tt3799232"",""titulo"":""A Barraca do Beijo"",""ano"":2018,""nota"":6.4},{""id"":""tt1365519"",""titulo"":""Tomb Raider: A Origem"",""ano"":2018,""nota"":6.5},{""id"":""tt1825683"",""titulo"":""Pantera Negra"",""ano"":2018,""nota"":7.5},{""id"":""tt5834262"",""titulo"":""Hotel Artemis"",""ano"":2018,""nota"":6.3},{""id"":""tt7690670"",""titulo"":""Superfly"",""ano"":2018,""nota"":5.1},{""id"":""tt6499752"",""titulo"":""Upgrade"",""ano"":2018,""nota"":7.8}]";

            _filmes = JsonConvert.DeserializeObject<List<Filme>>(filmesJson).ToArray();

        }

        [Fact]
        public void Verificar_se_retorna_vencedor_recebendo_dois_filmes()
        {
            
            var vencedor = new Partida().Jogar(_filmes[0], _filmes[1]);

            Assert.NotNull(vencedor);
        }

        [Fact]
        public void Verificar_se_retorna_erro_se_nao_receber_todos_os_times()
        {

            Assert.Throws<NullReferenceException>(() => new Partida().Jogar(_filmes[0], null));
        }


        [Fact]
        public void Verificar_se_retorna_erro_se_nao_receber_nenhum_filme()
        {
            Assert.Throws<NullReferenceException>(() => new Partida().Jogar(null, null));
        }

        [Fact]
        public void Verificar_se_retorna_filme_vencedor_correto_recebendo_dois_filmes()
        {

            var filmes = _filmes.ToList();
            var filmeUm = filmes.FirstOrDefault(x => x.Titulo == "Vingadores: Guerra Infinita");
            var filmeDois = filmes.FirstOrDefault(x => x.Titulo == "Os Incr�veis 2");
           


            var vencedor = new Partida().Jogar(filmeUm, filmeDois);
            

            Assert.True(vencedor.Titulo == "Vingadores: Guerra Infinita");
        }

        [Fact]
        public void Verificar_se_retorna_filme_vencedor_correto_recebendo_dois_filmes_com_mesma_nota()
        {

            var filmes = _filmes.ToList();
            filmes.FirstOrDefault(x => x.Titulo == "Vingadores: Guerra Infinita").Nota = 2;
            filmes.FirstOrDefault(x => x.Titulo == "Os Incr�veis 2").Nota = 2;

            var filmeUm = filmes.FirstOrDefault(x => x.Titulo == "Vingadores: Guerra Infinita");
            var filmeDois = filmes.FirstOrDefault(x => x.Titulo == "Os Incr�veis 2");

           
            var vencedor = new Partida().Jogar(filmeUm, filmeDois);


            Assert.True(vencedor.Titulo == "Os Incr�veis 2");
        }

    }
}
