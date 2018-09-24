export class User{
    User_ID:number;
    FirstName:string;
    LastName:string;
    Employee_ID:number;
    IsMgr:boolean;
    ProjectId:number;
    TaskId:number;
    constructor(uid:number,fname:string,lname:string,eid:number){
        this.User_ID=uid;
        this.FirstName=fname;
        this.LastName=lname;
        this.Employee_ID=eid;
    }
}