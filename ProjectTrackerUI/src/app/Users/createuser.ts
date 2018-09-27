export class CreateUser{
    FirstName:string;
    LastName:string;
    Employee_ID:number;
    constructor(fname:string,lname:string,eid:number){
        this.FirstName=fname;
        this.LastName=lname;
        this.Employee_ID=eid;
    }
}
export class ViewUser{
    FirstName:string;
    LastName:string;
    Employee_ID:number;
    User_ID:number;
    constructor(fname:string,lname:string,eid:number,uid:number){
        this.FirstName=fname;
        this.LastName=lname;
        this.Employee_ID=eid;
        this.User_ID=uid;
    }
}