using CopaDosFilmes.Aplicacao;
using CopaDosFilmes.Aplicacao.Interface;
using CopaDosFilmes.Dominios;
using CopaDosFilmes.UI.Controllers;
using CopaDosFimes.Repositorio;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CopaDosFilmes.WebTeste
{
    public class CopaFilmesControllerTeste
    {
        public CopaFilmesControllerTeste()
        {
            var filmesJson = @"[{""id"":""tt3606756"",""titulo"":""Os Incríveis 2"",""ano"":2018,""nota"":8.5},{""id"":""tt4881806"",""titulo"":""Jurassic World: Reino Ameaçado"",""ano"":2018,""nota"":6.7},{""id"":""tt5164214"",""titulo"":""Oito Mulheres e um Segredo"",""ano"":2018,""nota"":6.3},{""id"":""tt7784604"",""titulo"":""Hereditário"",""ano"":2018,""nota"":7.8},{""id"":""tt4154756"",""titulo"":""Vingadores: Guerra Infinita"",""ano"":2018,""nota"":8.8},{""id"":""tt5463162"",""titulo"":""Deadpool 2"",""ano"":2018,""nota"":8.1},{""id"":""tt3778644"",""titulo"":""Han Solo: Uma História Star Wars"",""ano"":2018,""nota"":7.2},{""id"":""tt3501632"",""titulo"":""Thor: Ragnarok"",""ano"":2017,""nota"":7.9},{""id"":""tt2854926"",""titulo"":""Te Peguei!"",""ano"":2018,""nota"":7.1},{""id"":""tt0317705"",""titulo"":""Os Incríveis"",""ano"":2004,""nota"":8.0},{""id"":""tt3799232"",""titulo"":""A Barraca do Beijo"",""ano"":2018,""nota"":6.4},{""id"":""tt1365519"",""titulo"":""Tomb Raider: A Origem"",""ano"":2018,""nota"":6.5},{""id"":""tt1825683"",""titulo"":""Pantera Negra"",""ano"":2018,""nota"":7.5},{""id"":""tt5834262"",""titulo"":""Hotel Artemis"",""ano"":2018,""nota"":6.3},{""id"":""tt7690670"",""titulo"":""Superfly"",""ano"":2018,""nota"":5.1},{""id"":""tt6499752"",""titulo"":""Upgrade"",""ano"":2018,""nota"":7.8}]";

            _filmes = JsonConvert.DeserializeObject<List<Filme>>(filmesJson);
            copaFilmesController = new CopaFilmesController(new CopaDosFilmesApl(new CopaDosFilmesRepositorio()));
        }

        private List<Filme> _filmes;

        private CopaFilmesController copaFilmesController;


        [Fact]
        public void Verificar_se_retorna_resultado_recebendo_oito_filmes()
        {
            var filmes = _filmes.GetRange(0, 8);
            var resultado = copaFilmesController.Post(filmes);

            Assert.NotNull(resultado);
        }

        [Fact]
        public void Verificar_se_retorna_erro_se_nao_receber_todos_os_times()
        {
            var filmes = _filmes.GetRange(0, 5);

            Assert.Throws<Exception>(() => copaFilmesController.Post(filmes));
        }

        [Fact]
        public void Verificar_se_retorna_erro_se_receber_mais_de_oito_times()
        {
            var filmes = _filmes.GetRange(0, 12);

            Assert.Throws<Exception>(() => copaFilmesController.Post(filmes));
        }

        [Fact]
        public void Verificar_se_retorna_erro_se_nao_receber_nenhum_filme()
        {

            var filmes = new List<Filme>();

            Assert.Throws<Exception>(() => copaFilmesController.Post(filmes));
        }

        [Fact]
        public void Verificar_se_retorna_filmes_corretos_no_resultado_recebendo_oito_filmes()
        {

            var filmes = new List<Filme>
            {
                _filmes.FirstOrDefault(x => x.Titulo == "Deadpool 2"),
                _filmes.FirstOrDefault(x => x.Titulo == "Han Solo: Uma História Star Wars"),
                _filmes.FirstOrDefault(x => x.Titulo == "Hereditário"),
                _filmes.FirstOrDefault(x => x.Titulo == "Jurassic World: Reino Ameaçado"),
                _filmes.FirstOrDefault(x => x.Titulo == "Oito Mulheres e um Segredo"),
                _filmes.FirstOrDefault(x => x.Titulo == "Os Incríveis 2"),
                _filmes.FirstOrDefault(x => x.Titulo == "Thor: Ragnarok"),
                _filmes.FirstOrDefault(x => x.Titulo == "Vingadores: Guerra Infinita")
            };

            var resultado = copaFilmesController.Post(filmes);

            bool filme1 = resultado.Final.Filmes[0].Titulo == "Vingadores: Guerra Infinita";
            bool filme2 = resultado.Final.Filmes[1].Titulo == "Os Incríveis 2";
            bool campeao = resultado.Campeao.Titulo == "Vingadores: Guerra Infinita";
            bool vice = resultado.Vice.Titulo == "Os Incríveis 2";

            Assert.True(filme1 && filme2 && campeao && vice);
        }

        [Fact]
        public void Verificar_se_esta_retornando_a_lista_de_filmes()
        {
            var mock = new Mock<ICopaDosFilmesApl>();
            mock.Setup(p => p.ListarFilmes()).Returns(_filmes);
            copaFilmesController = new CopaFilmesController(mock.Object);
            var resultado = copaFilmesController.Get();

            Assert.True(resultado.Count() > 0);
        }

    }
}
