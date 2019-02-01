import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { ResultadoComponent } from './resultado/resultado.component';
import { InicioComponent } from './inicio/inicio.component';
import { CopaDosFilmesService } from './services/copa-dos-filmes.service';

@NgModule({
  declarations: [
    AppComponent,
    ResultadoComponent,
    InicioComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: InicioComponent, pathMatch: 'full' },
      { path: 'inicio', component: InicioComponent},
      { path: 'resultado', component: ResultadoComponent},
    ])
  ],
  providers: [CopaDosFilmesService],
  bootstrap: [AppComponent]
})
export class AppModule { }
