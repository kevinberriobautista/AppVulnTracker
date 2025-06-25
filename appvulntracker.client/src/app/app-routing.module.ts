import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthComponent } from './auth/auth.component';
import { InicioComponent } from './inicio/inicio.component';
import { TestVulnerabilidadesComponent } from './test-vulnerabilidades/test-vulnerabilidades.component';
import { authGuard } from './auth/auth.guard';
import { VulnerabilidadesComponent } from './vulnerabilidades/vulnerabilidades.component';
import { ListaVulnerabilidadesComponent } from './lista-vulnerabilidades/lista-vulnerabilidades.component';
import { EditarVulnerabilidadesComponent } from './editar-vulnerabilidades/editar-vulnerabilidades.component';

const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login', component: AuthComponent },
  { path: 'inicio', component: InicioComponent, canActivate: [authGuard] },
  { path: 'testvulnerabilidades', component: TestVulnerabilidadesComponent, canActivate: [authGuard] },
  { path: 'vulnerabilidades', component: VulnerabilidadesComponent, canActivate: [authGuard] },
  { path: 'lista-vulnerabilidades', component: ListaVulnerabilidadesComponent, canActivate: [authGuard] },
  { path: 'editar-vulnerabilidades', component: EditarVulnerabilidadesComponent, canActivate: [authGuard] },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
