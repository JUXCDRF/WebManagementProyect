import { Routes } from '@angular/router';
import { ProyectoComponent } from './proyecto.component';
import { ProyectoRegistrarComponent } from '../proyecto-registrar/proyecto-registrar.component';

export const proyectoRoutes: Routes = [
  {
    path: '',
    component: ProyectoComponent,
    children: [
      {path:"proyecto/registrar",component:ProyectoRegistrarComponent}
    ]
  }
];
