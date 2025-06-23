import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthComponent } from './auth/auth.component';
import { VulnerabilidadesComponent } from './vulnerabilidades/vulnerabilidades.component';
import { ComentariosComponent } from './comentarios/comentarios.component';
import { ArchivosComponent } from './archivos/archivos.component';
import { UsuariosComponent } from './usuarios/usuarios.component';
import { InicioComponent } from './inicio/inicio.component';
import { TestVulnerabilidadesComponent } from './test-vulnerabilidades/test-vulnerabilidades.component';

@NgModule({
  declarations: [
    AppComponent,
    AuthComponent,
    UsuariosComponent,
    VulnerabilidadesComponent,
    ArchivosComponent,
    ComentariosComponent,
    InicioComponent,
    TestVulnerabilidadesComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule, FormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
