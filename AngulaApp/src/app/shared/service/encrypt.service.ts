import * as CryptoJS from 'crypto-js';
import { inject, Injectable } from '@angular/core';
import { SecurestorageService } from './securestorage.service';
import { enviroment } from '../../../enviroments/constantes.develoment';

@Injectable({
  providedIn: 'root'
})
export class EncryptService {

  private storageService=inject(SecurestorageService);
   // Crea la clave combinada y cifrada en base64
  generateSecurePayload(alias: string, token: string): string {
    const mitad = token.slice(0, Math.floor(token.length / 2));
    const data = alias + mitad;

    //const encrypted = CryptoJS.AES.encrypt(data, token).toString();
    return btoa(data); // codifica en base64 para enviar
  }
  textoCifrado(texto:string,token: string):string{
    const cadena=texto;
    const cifrado=CryptoJS.AES.encrypt(cadena,token).toString();
    return btoa(cifrado);
  }
  textoDecifrado(texto:string):string{
    const key=enviroment.KEYSTORAGE;
    const token=this.storageService.get(key);
    if(token==""){
      return "Error";
    }
    const descifrado=CryptoJS.AES.encrypt(texto,token).toString();
    return descifrado;
  }
}
