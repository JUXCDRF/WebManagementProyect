export interface IproyectoTarea{
    tituloprincipal:string
    tareas:ItareaList[],
    pagesize:number,
    pagenumber:number,
    totalcount:number
}

export interface ItareaList {
    id:string,
    fecha:string
    horainicio:string,
    horafin:string,
    titulo:string,
    descripcion:string,
    estado:number
}
