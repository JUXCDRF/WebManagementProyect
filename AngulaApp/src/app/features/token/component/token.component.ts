import { Component,inject } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { ItokenRequest } from '../modals/itoken-request';
import { EncryptService } from '../../../shared/service/encrypt.service';
import { TokenService } from '../service/token.service';
import { SecurestorageService } from '../../../shared/service/securestorage.service';
import { enviroment } from '../../../../enviroments/constantes.develoment';

@Component({
  selector: 'app-token',
  standalone:true,
  imports: [
    ReactiveFormsModule
  ],
  templateUrl: './token.component.html',
  styleUrl: './token.component.css'
})
export class TokenComponent {  
  registrar:boolean=true;
  validar:boolean=false;  
  private encryptSevice=inject(EncryptService);
  private tokenService=inject(TokenService);
  private storageService=inject(SecurestorageService);
  ngOnInit(){

  }

  frmTokenDatos=new FormGroup({
    token:new FormControl(),
    alias:new FormControl()
  })


  funRegistrar(){
    const key=enviroment.KEYSTORAGE;
    const token=this.frmTokenDatos.get("token")?.value||"";
    const alias=this.frmTokenDatos.get("alias")?.value||"";

    const paylodEnviar= this.encryptSevice.generateSecurePayload(alias,token);
    const aliasEnviar=this.encryptSevice.textoCifrado(alias,token);
    const ItokenRequest:ItokenRequest={
      token:paylodEnviar,
      alias:aliasEnviar
    }
    this.tokenService.saveToken(ItokenRequest).subscribe({
      next:(res)=>{
        if(!res.success){
          alert(res.message);
          return;
        }
        alert(res.message);
        this.storageService.save(key,paylodEnviar);
      },
      error:(error)=>{
        const mensaje = error.error?.message || 'Ocurrió un error inesperado';
        alert(mensaje);
      }
    })
  }
  funValidar(){
    
  }
}
