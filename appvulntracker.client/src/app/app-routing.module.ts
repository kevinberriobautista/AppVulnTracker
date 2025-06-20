import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthComponent } from './auth/auth.component'; // importa tu componente de login

const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' }, // ruta por defecto redirige a login
  { path: 'login', component: AuthComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
