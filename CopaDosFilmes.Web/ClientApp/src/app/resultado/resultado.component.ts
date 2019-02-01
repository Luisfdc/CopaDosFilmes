import { Component } from '@angular/core';
import { Router, NavigationExtras, ActivatedRoute } from "@angular/router";
import { CopaDosFilmesService } from '../services/copa-dos-filmes.service';

@Component({
  selector: 'app-resultado-component',
  templateUrl: './resultado.component.html',
  styleUrls: ['./resultado.component.css']
})
export class ResultadoComponent {
  public currentCount = 0;
  public orderObj:any;
  public resultado: any;

  constructor(private copaFilmesService: CopaDosFilmesService) {
  }

  ngOnInit() {
    this.resultado = this.copaFilmesService.ObterResultado();
    console.log(this.resultado);
  }
}
