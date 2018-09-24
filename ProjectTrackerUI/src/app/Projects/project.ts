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