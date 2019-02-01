import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Ifilme } from '../interfaces/ifilme';
import { Router } from '@angular/router';

@Injectable()
export class CopaDosFilmesService {
  private resultado:any;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string,private router: Router) { }

  ObterListaFilmes() {
    return this.http.get<Ifilme[]>(this.baseUrl+'api/CopaFilmes');
  }

  GerarCampeonato(filmesSelecionados:Ifilme[]) {
    this.http.post(this.baseUrl + "api/CopaFilmes", filmesSelecionados).subscribe(data  => {
      this.resultado = data;
      
    this.router.navigate(['/resultado']);
    },error  => {
      console.log("Error", error);
    });
  }

  ObterResultado() {
    return this.resultado;
  }
}
