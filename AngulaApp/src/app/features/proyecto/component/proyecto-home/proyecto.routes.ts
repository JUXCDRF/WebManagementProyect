import { Routes } from '@angular/router';
import { ProyectoComponent } from './proyecto.component';
import { ProyectoRegistrarComponent } from '../proyecto-registrar/proyecto-registrar.component';
import { ProyectoTareaComponent } from '../proyecto-tarea/proyecto-tarea.component';

export const proyectoRoutes: Routes = [
  {
    path: 'proyecto',
    component: ProyectoComponent,
    children: [
      {path:"registrar",component:ProyectoRegistrarComponent},
      {path:"tarea/:id",component:ProyectoTareaComponent}
    ]
  }
];
