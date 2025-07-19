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
import { ProyectotareaClass } from '../modals/proyectotarea-class';
import { ItareaListRequest } from '../modals/itarea-list-request';

@Injectable({
  providedIn: 'root'
})
export class ProyectoService {
  private UriList=`${enviroment.URLBASE}api/Proyecto/Listar`;
  private UriFiltrar=`${enviroment.URLBASE}api/Proyecto/Filtrar`;
  private UriRegistrar=`${enviroment.URLBASE}api/Proyecto/Registrar`;
  private GetTarea=`${enviroment.URLBASE}api/Proyecto`;

  private httpclient=inject(HttpClient);

  getLista(IOnlytokenRequest:IonlytokenRequest):Observable<IproyectoList[]>{
    return this.httpclient.post<IproyectoList[]>(this.UriList,IOnlytokenRequest);
  }

  saveProyecto(IProyectoRequest:Iproyectorequest):Observable<Baseresponse>{
      return this.httpclient.post<Baseresponse>(this.UriRegistrar,IProyectoRequest);
  }

  getById(ItareaListRequest:ItareaListRequest):Observable<IproyectoTarea>{
    const id=ItareaListRequest.id;
    const token=ItareaListRequest.token;
    const pagesize=ItareaListRequest.pagesize??5;
    const pagenumber=ItareaListRequest.pagenumber??1;
    const url=`${this.GetTarea}/${id}/Tarea/Listar?token=${token}&pagesize=${pagesize}&pagenumber=${pagenumber}`;
    return this.httpclient.get<IproyectoTarea>(url);
  }

  getFiltro(IfiltroRequest:IfiltroRequest):Observable<IproyectoList[]>{
    return this.httpclient.post<IproyectoList[]>(this.UriFiltrar,IfiltroRequest);
  }

}
