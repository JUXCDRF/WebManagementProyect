import { ItareaList } from "./itarea-list";

export class ProyectotareaClass {
    tituloprincipal:string;
    tareas:ItareaList[];
    pagesize:number;
    pagenumber:number;
    totalcount:number;
    rangepage?:number[];
    pagefinal?:number;

    constructor(tituloprincipal:string="",tareas:ItareaList[]=[],pagesize:number=0,pagenumber:number=0,totalcount:number=0){
        this.tituloprincipal=tituloprincipal??"";
        this.tareas=tareas??[];
        this.pagesize=pagesize>0?pagesize:1;
        this.pagenumber=pagenumber??1;
        this.totalcount=totalcount??0;
        //this.pagenumber=this.pagenumber??1;
        const pagefinal:number=Math.ceil(this.totalcount/this.pagesize);
        this.pagefinal=pagefinal==0?1:pagefinal;
        this.rangepage= Array.from({length:this.pagefinal},(_,i)=>i+1);
    }
}
