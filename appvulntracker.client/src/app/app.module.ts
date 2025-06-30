import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { MatExpansionModule } from '@angular/material/expansion';
import { LOCALE_ID } from '@angular/core';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthComponent } from './auth/auth.component';
import { VulnerabilidadesComponent } from './vulnerabilidades/vulnerabilidades.component';
import { ComentariosComponent } from './comentarios/comentarios.component';
import { ArchivosComponent } from './archivos/archivos.component';
import { UsuariosComponent } from './usuarios/usuarios.component';
import { InicioComponent } from './inicio/inicio.component';
import { TestVulnerabilidadesComponent } from './test-vulnerabilidades/test-vulnerabilidades.component';
import { ListaVulnerabilidadesComponent } from './lista-vulnerabilidades/lista-vulnerabilidades.component';
import { EditarVulnerabilidadesComponent } from './editar-vulnerabilidades/editar-vulnerabilidades.component';
import { HistorialComponent } from './historial/historial.component';
import { CrearVulnerabilidadPorTestComponent } from './crear-vulnerabilidad-por-test/crear-vulnerabilidad-por-test.component';

@NgModule({
  declarations: [
    AppComponent,
    AuthComponent,
    UsuariosComponent,
    VulnerabilidadesComponent,
    ArchivosComponent,
    ComentariosComponent,
    InicioComponent,
    TestVulnerabilidadesComponent,
    ListaVulnerabilidadesComponent,
    EditarVulnerabilidadesComponent,
    HistorialComponent,
    CrearVulnerabilidadPorTestComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule, FormsModule, MatExpansionModule,
  ],
  providers: [
    { provide: LOCALE_ID, useValue: 'es' }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
