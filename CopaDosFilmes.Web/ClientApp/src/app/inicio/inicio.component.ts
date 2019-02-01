import { Component, OnInit } from '@angular/core';
import { Router } from "@angular/router";

import { Ifilme } from '../interfaces/ifilme';
import { CopaDosFilmesService } from '../services/copa-dos-filmes.service';

@Component({
  selector: 'app-inicio',
  templateUrl: './inicio.component.html',
  styleUrls: ['./inicio.component.css']
})

export class InicioComponent implements OnInit {
  public filmes: Ifilme[];
  public selectable: boolean;
  private qtdSelecicted:number = 0;
  
  constructor(private copaFilmesService: CopaDosFilmesService) {}

  ngOnInit(){
    this.copaFilmesService.ObterListaFilmes().subscribe(result => {
      this.filmes = result;
    }, error => {
      console.error(error);
    })
  }

  public select(){
    
    this.qtdSelecicted = this.filmes.filter(function(filme){
      if(filme.selecionado)
      return filme
    }).length;

    this.selectable = this.qtdSelecicted >= 8;
    }

  public gerarMeuCampeonato() {
    let filmesSelecionados = this.filmes.filter(function (filme) {
      if (filme.selecionado == true)
        return filme;
    });

    this.copaFilmesService.GerarCampeonato(filmesSelecionados);
  }
}

