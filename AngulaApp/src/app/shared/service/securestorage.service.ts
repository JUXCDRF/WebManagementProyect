import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SecurestorageService {
  save(key: string, value: string): void {
    //const encrypted = btoa(value); //CryptoJS.AES.encrypt(value, SECRET_KEY).toString();
    sessionStorage.setItem(key, value); // o localStorage
  }

  get(key: string): string {
    const encrypted = sessionStorage.getItem(key);
    if (!encrypted) return "";
    return atob(encrypted);
  }
  getCode(key:string):string{
    const encrypted = sessionStorage.getItem(key);
    if (!encrypted) return "";
    return encrypted;
  }
  remove(key: string): void {
    sessionStorage.removeItem(key);
  }

  clear(): void {
    sessionStorage.clear();
  }
}
