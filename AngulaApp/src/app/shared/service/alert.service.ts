import { Injectable } from '@angular/core';
import Swal from 'sweetalert2'
@Injectable({
  providedIn: 'root'
})
export class AlertService {

  funAlert(message:string,type:'success' | 'error' | 'warning' | 'info' | 'question'){
    //success //error
    Swal.fire({
      title: message,
      icon: type,
      showCancelButton: false,
      cancelButtonText: 'Cerrar'
    });
  }

 async funAlertConsulta(estado:string):Promise<boolean>{
    const alerta= await Swal.fire({
      title: `Seguro que quieres ${estado}?`,
      showDenyButton: true,
      showCancelButton: false,
      confirmButtonText: `${estado}`,
      denyButtonText: `No`
    });
    if (alerta.isConfirmed) {
        return true;
        //Swal.fire("Saved!", "", "success");
      } else if (alerta.isDenied) {
        return false;
        //Swal.fire("Changes are not saved", "", "info");
      }else{
        return false;
      }
  }
}
