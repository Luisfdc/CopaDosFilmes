using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CopaDosFilmes.Aplicacao.Interface;
using CopaDosFilmes.Dominios;
using Microsoft.AspNetCore.Mvc;

namespace CopaDosFilmes.UI.Controllers
{
    [Route("api/[controller]")]
    public class CopaFilmesController : Controller
    {
        private ICopaDosFilmesApl _CopaDosFilmesApl;

        public CopaFilmesController(ICopaDosFilmesApl CopaDosFilmesApl)
        {
            _CopaDosFilmesApl = CopaDosFilmesApl;
        }

        [HttpGet]
        public IEnumerable<Filme> Get()
        {
            return _CopaDosFilmesApl.ListarFilmes();
        }

         [HttpPost]
        public Dominios.CopaDosFilmes Post([FromBody]List<Filme> filmes)
        {
            return _CopaDosFilmesApl.GerarMeuCampeonato(filmes);
        }
        
    }
}
