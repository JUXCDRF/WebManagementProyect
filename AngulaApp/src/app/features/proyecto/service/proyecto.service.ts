import { inject, Injectable } from '@angular/core';
import { enviroment } from '../../../../enviroments/constantes.develoment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IproyectoList } from '../modals/iproyecto-list';
import { Iproyectorequest } from '../modals/iproyecto-request';
import { Baseresponse } from '../../../shared/interface/baseresponse';
import { IonlytokenRequest } from '../../../shared/popup/interface/ionlytoken-request';
import { IproyectoTarea } from '../modals/itarea-list';
import { IfiltroRequest } from '../modals/ifiltro-request';

@Injectable({
  providedIn: 'root'
})
export class ProyectoService {
  private UriList=`${enviroment.URLBASE}api/Proyecto/Listar`
  private UriFiltrar=`${enviroment.URLBASE}api/Proyecto/Filtrar`
  private UriRegistrar=`${enviroment.URLBASE}api/Proyecto/Registrar`
  private GetTarea=`${enviroment.URLBASE}api/Proyecto/Tarea`

  private httpclient=inject(HttpClient);

  getLista(IOnlytokenRequest:IonlytokenRequest):Observable<IproyectoList[]>{
    return this.httpclient.post<IproyectoList[]>(this.UriList,IOnlytokenRequest);
  }

  saveProyecto(IProyectoRequest:Iproyectorequest):Observable<Baseresponse>{
      return this.httpclient.post<Baseresponse>(this.UriRegistrar,IProyectoRequest);
  }

  getById(id:string,token:string):Observable<IproyectoTarea>{
    const url=`${this.GetTarea}/${id}?token=${token}`;
    return this.httpclient.get<IproyectoTarea>(url);
  }

  getFiltro(IfiltroRequest:IfiltroRequest):Observable<IproyectoList[]>{
    return this.httpclient.post<IproyectoList[]>(this.UriFiltrar,IfiltroRequest);
  }

}
