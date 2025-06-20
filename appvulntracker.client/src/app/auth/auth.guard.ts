import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { LoginService } from '../auth/login.service';

export const authGuard: CanActivateFn = (route, state) => {
  const loginService = inject(LoginService);
  const router = inject(Router);

  const usuario = loginService.usuarioSubject.value;

  if (usuario) {
    return true;
  } else {
    router.navigate(['/login']);
    return false;
  }
};
