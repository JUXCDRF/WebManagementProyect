import { inject, Injectable } from '@angular/core';
import { enviroment } from '../../../../../../enviroments/constantes.develoment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Baseresponse } from '../../../../../shared/interface/baseresponse';
import { ItareaCrearRequest } from '../models/itarea-crear-request';
import { ItareaResponse } from '../models/itarea-response';
import { ItareaEstadoRequest } from '../models/itarea-estado-request';
import { IonlytokenRequest } from '../../../../../shared/popup/interface/ionlytoken-request';

@Injectable({
  providedIn: 'root'
})
export class ItareaRequestService {
  private UriRegistrar=`${enviroment.URLBASE}api/Tarea/Registrar`;
  private UriActualizar=`${enviroment.URLBASE}api/Tarea`;
  private httpcliente=inject(HttpClient);

  SaveTarea(ItareaCrearRequest:ItareaCrearRequest):Observable<Baseresponse>{
    return this.httpcliente.post<Baseresponse>(this.UriRegistrar,ItareaCrearRequest);
  }

  UpdateTarea(ItareaCrearRequest:ItareaCrearRequest):Observable<Baseresponse>{
    const url=`${this.UriActualizar}/Actualizar`;
    return this.httpcliente.post<Baseresponse>(url,ItareaCrearRequest);
  }

  GetTarea(idTarea:string,token:string):Observable<ItareaResponse>{
    const url=`${this.UriActualizar}/${idTarea}`;
    const request:IonlytokenRequest={
      token:token
    }
    return this.httpcliente.post<ItareaResponse>(url,request);
  }

  UpdateEstado(idTarea:string,token:string,estado:number):Observable<Baseresponse>{
    const url=`${this.UriActualizar}/${idTarea}/Estado`;
    const request:ItareaEstadoRequest={
      estado:estado,
      token:token
    }
    return this.httpcliente.post<Baseresponse>(url,request);
  }

}
