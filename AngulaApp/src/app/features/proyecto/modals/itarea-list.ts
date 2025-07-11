export interface IproyectoTarea{
    tituloprincipal:string
    tareas:ItareaList[]
}

export interface ItareaList {
    id:string,
    fecha:string
    horainicio:string,
    horafin:string,
    titulo:string,
    descripcion:string
}
