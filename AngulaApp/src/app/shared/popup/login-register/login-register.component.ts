import { Component, inject, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { IpopupRequest } from '../interface/ipopup-request';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { enviroment } from '../../../../enviroments/constantes.develoment';
import { EncryptService } from '../../service/encrypt.service';
import { TokenService } from '../service/token.service';
import { SecurestorageService } from '../../service/securestorage.service';
import { ItokenRequest } from '../interface/itoken-request';
import { IonlytokenRequest } from '../interface/ionlytoken-request';
import { IpopupResponse } from '../interface/ipopup-response';
import { AlertService } from '../../service/alert.service';

@Component({
  selector: 'app-login-register',
  imports: [
    ReactiveFormsModule
  ],
  templateUrl: './login-register.component.html',
  styleUrl: './login-register.component.css'
})
export class LoginRegisterComponent {
  constructor(
    public dialogRef:MatDialogRef<LoginRegisterComponent>,
    @Inject(MAT_DIALOG_DATA) public data:IpopupRequest
  ){}

  private encryptSevice=inject(EncryptService);
  private tokenService=inject(TokenService);
  private storageService=inject(SecurestorageService);
  private alertService=inject(AlertService);
  frmTokenDatos=new FormGroup({
    token:new FormControl(),
    alias:new FormControl()
  })

  funRegistrar(){
    if(!this.data.registrar){return;}
    const key=enviroment.KEYSTORAGE;
    const token=this.frmTokenDatos.get("token")?.value||"";
    const alias=this.frmTokenDatos.get("alias")?.value||"";

    const tokenEnviar=this.encryptSevice.generarCombinacion(alias,token);
    const paylodEnviar= this.encryptSevice.generateSecurePayload(tokenEnviar);//BASE64
    const aliasEnviar=alias;//TOKEN NORMAL

    const ItokenRequest:ItokenRequest={
      token:paylodEnviar,
      alias:aliasEnviar
    }

    this.tokenService.saveToken(ItokenRequest).subscribe({
      next:(res)=>{
        if(!res.success){
          this.alertService.funAlert(res.message,"error");
          this.dialogRef.close(false);
        }
        this.storageService.save(key,paylodEnviar);
        this.alertService.funAlert(res.message,"success");

        const response:IpopupResponse={
          token:this.storageService.getCode(key),
          success:true
        }
        this.dialogRef.close(response);
      },
      error:(error)=>{
        const mensaje = error.error?.message || 'Ocurrió un error inesperado';
        this.alertService.funAlert(mensaje,"error");
      }
    });
  }

  funValidar(){
    if(!this.data.validar){return;}
    const key=enviroment.KEYSTORAGE;
    const token=this.frmTokenDatos.get("token")?.value||"";
    const alias=this.frmTokenDatos.get("alias")?.value||"";

    const tokenEnviar=this.encryptSevice.generarCombinacion(alias,token);
    const paylodEnviar= this.encryptSevice.generateSecurePayload(tokenEnviar);

    const IOnlytokenRequest:IonlytokenRequest={
      token:paylodEnviar,
    }

     this.tokenService.signToken(IOnlytokenRequest).subscribe({
      next:(res)=>{
        if(!res.success){
          this.alertService.funAlert(res.message,"error");
          this.dialogRef.close(false);
        }
        this.storageService.save(key,paylodEnviar);
        const aliasRespuesta=res.message;
        const response:IpopupResponse={
          token:this.storageService.getCode(key),
          success:true
        }
        this.alertService.funAlert(`Bienvenido: ${aliasRespuesta}`,"success");
        this.dialogRef.close(response);
      },
      error:(error)=>{
        const mensaje = error.error?.message || 'Ocurrió un error inesperado';
        this.alertService.funAlert(mensaje,"error");
      }
    });

  }

  cerrar() {
    this.dialogRef.close();
  }

  CambiarRegistro(){
    this.data.registrar=true;
    this.data.validar=false;
  }
}



