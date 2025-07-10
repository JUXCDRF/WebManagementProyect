import { inject, Injectable } from '@angular/core';
import { enviroment } from '../../../../enviroments/constantes.develoment';
import { HttpClient } from '@angular/common/http';
import { ItokenRequest } from '../interface/itoken-request';
import { Observable } from 'rxjs';
import { Baseresponse } from '../../interface/baseresponse';

@Injectable({
  providedIn: 'root'
})
export class TokenService {
  urlTokenRegister=`${enviroment.URLBASE}api/Token/Registrar`
  urlTokenSign=`${enviroment.URLBASE}api/Token/Validar`
  private httpclient=inject(HttpClient);

  saveToken(ItokenRequest:ItokenRequest):Observable<Baseresponse>{
    return this.httpclient.post<Baseresponse>(this.urlTokenRegister,ItokenRequest);
  }
  signToken(ItokenRequest:ItokenRequest):Observable<Baseresponse>{
    return this.httpclient.post<Baseresponse>(this.urlTokenSign,ItokenRequest);
  }

}
