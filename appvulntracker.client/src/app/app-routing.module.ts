import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthComponent } from './auth/auth.component';
import { InicioComponent } from './inicio/inicio.component';
import { TestVulnerabilidadesComponent } from './test-vulnerabilidades/test-vulnerabilidades.component';
import { authGuard } from './auth/auth.guard';

const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login', component: AuthComponent },
  { path: 'inicio', component: InicioComponent, canActivate: [authGuard] },
  { path: 'testvulnerabilidades', component: TestVulnerabilidadesComponent, canActivate: [authGuard] },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
