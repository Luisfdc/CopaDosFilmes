﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CopaDosFilmes.Dominios
{
    public class Filme
    {
        public string Id { get; set; }
        public string Titulo { get; set; }
        public int Ano { get; set; }
        public decimal Nota { get; set; }
    }
}
