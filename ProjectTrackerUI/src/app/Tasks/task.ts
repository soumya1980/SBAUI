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
export class ViewTask{
    TaskID:number;
    TaskName:string;
    StartDate:any;
    EndDate:any;
    Priority:number;
    Status:string;
    ParentTaskID:number;
    ParentTask:string;
    ProjectID:number;
    ProjectDesc:string
    constructor(tid:number,tname:string,stdt :any,enddt:any,priority:number,status:string,
        ptid:number,ptask:string,pid :number,pdesc:string){
            this.TaskID=tid;
            this.TaskName=tname;
            this.StartDate=stdt;
            this.EndDate=enddt;
            this.Priority=priority;
            this.Status=status;
            this.ParentTaskID=ptid;
            this.ParentTask=ptask;
            this.ProjectID=pid;
            this.ProjectDesc=pdesc;
    }
}