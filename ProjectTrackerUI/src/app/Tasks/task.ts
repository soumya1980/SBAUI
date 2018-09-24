export class Task{
    TaskName:string;
    StartDt:string;
    EndDt:string;
    Priority:number;
    Status:string
    constructor(tanme:string,stdt:string,enddt:string,priority:number,status:string){
        this.TaskName=tanme;
        this.StartDt=stdt;
        this.EndDt=enddt;
        this.Priority=priority;
        this.Status=status;
    }
}
export class CreateTask{
    projectid:number;
    parentTaskId:number;
    userId:number;
    task:Task;
    constructor(pid:number,ptaskid:number,uid:number,task:Task){
        this.projectid=pid;
        this.parentTaskId=ptaskid;
        this.userId=uid;
        this.task=task;
    }
}