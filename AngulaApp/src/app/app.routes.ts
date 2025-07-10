import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('./shared/home/home.routes').then(m => m.homeRoutes)
  }
];
