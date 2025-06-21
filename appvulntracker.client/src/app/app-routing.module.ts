import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthComponent } from './auth/auth.component'; // importo el componente de login
import { InicioComponent } from './inicio/inicio.component'; // importo el componente de login
import { authGuard } from './auth/auth.guard';  // Importo el guard
import { TestVulnerabilidadesComponent } from './test-vulnerabilidades/test-vulnerabilidades.component';

const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' }, // ruta por defecto redirige a login
  { path: 'login', component: AuthComponent },
  { path: 'inicio', component: InicioComponent, canActivate: [authGuard] },
  { path: 'testvulnerabilidades', component: TestVulnerabilidadesComponent, canActivate: [authGuard] },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
