import { Routes } from '@angular/router';
import { HomeComponent } from './home.component';
import { ProyectoComponent } from '../../features/proyecto/component/proyecto-home/proyecto.component';
import { BienvenidoComponent } from '../../features/bienvenido/bienvenido.component';

export const homeRoutes: Routes = [
  {
    path: '',
    component: HomeComponent,
    children: [
      { path: 'proyecto',loadChildren: () => import('../../features/proyecto/component/proyecto-home/proyecto.routes').then(m => m.proyectoRoutes)},
      { path: 'bienvenido',component:BienvenidoComponent}
    ]
  }
];
