export class Project{
    employyeId :number;
    userProject :UserProject;
    constructor(eid:number,usrproject :UserProject){
        this.employyeId=eid;
        this.userProject=usrproject;
    }
}
export class UserProject{
    ProjectDesc :string;
    StartDt:string;
    EndDt:string;
    Priority:number
    constructor(pdesc :string,stdt:string,enddt:string,priority:number){
        this.ProjectDesc=pdesc;
        this.StartDt=stdt;
        this.EndDt=enddt;
        this.Priority=priority;
    }
}
export class ProjectAndStatus{
    ProjectID:number;
    ProjectDesc:string;
    StartDate:Date;
    EndDate:Date;
    Priority:number;
    Status:string;
    TaskNos:number;
    constructor(pid:number,pdesc:string,stdt:Date,enddt:Date,priority:number,status:string,tno:number){
        this.ProjectID=pid;
        this.ProjectDesc=pdesc;
        this.StartDate=stdt;
        this.EndDate=enddt;
        this.Priority=priority;
        this.Status=status;
        this.TaskNos=tno;
    }
}