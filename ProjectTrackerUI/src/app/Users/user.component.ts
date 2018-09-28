import { Component } from "@angular/core";
import { User } from "src/app/Users/User";
import { UserService } from "src/app/Users/user.service";
import { error } from "@angular/compiler/src/util";
import { CreateUser, ViewUser } from "src/app/Users/createuser";
import { OnInit } from "@angular/core/src/metadata/lifecycle_hooks";

@Component({
    templateUrl: './user.component.html'
})
export class UserComponent implements OnInit {
    key:string='FirstName';
    reverse:boolean=false;
    userId:number;
    isEdit:boolean =false;
    errorMessage: string;
    firstName: string;
    lastName: string;
    employeeId: number;
    listViewUser :CreateUser[]=[];
    listFilteredUser:CreateUser[]=[];
    _searchUserText:string;
    get searchUserText(){
        return this._searchUserText;
    }
    set searchUserText(value:string){
        this._searchUserText=value;
        this.listFilteredUser=this.searchUserText ? this.PerformFilter():this.listViewUser;
    }
    constructor(private userService: UserService) {
        this.listFilteredUser = this.listViewUser;
    }
    PerformFilter(): CreateUser[] {
        let filterBy = this.searchUserText.toLocaleLowerCase();
        this.listFilteredUser= this.listViewUser.filter((user: CreateUser) => user.FirstName.toLocaleLowerCase().indexOf(filterBy) !== -1);
        return this.listFilteredUser;
    }
    PerformFilterByKey(key){
        this.key=key;
        this.reverse = !this.reverse;
    }
    createUser(): void {
        console.log('User clicked');
        let userData = new CreateUser(this.firstName, this.lastName, this.employeeId);
        this.userService.createUser(userData).subscribe(
            res => {
                console.log('User Created' + JSON.stringify(res));
            },
            error => this.errorMessage = <any>error
        );
    }
    editUser():void{
        let userData = new ViewUser(this.firstName, this.lastName, this.employeeId,this.userId);
        this.userService.patchUser(userData.User_ID,userData).subscribe(
            res => {
                console.log('User Updated' + JSON.stringify(res));
            },
            error => this.errorMessage = <any>error
        );
    }
    resetUser():void{
        this.employeeId=null;
        this.firstName="";
        this.lastName="";
        this.isEdit=false;
    }
    updateUser(user:any): void {
        console.log(user);
        this.employeeId=user.Employee_ID;
        this.firstName=user.FirstName;
        this.lastName=user.LastName;
        this.userId=user.User_ID;
        this.isEdit=true;
    }
    deleteUser(id:any): void {
        console.log(id);
        this.userService.deleteUser(id).subscribe(
            res => {
                console.log('User Deleted' + JSON.stringify(res));
            },
            error => this.errorMessage = <any>error
        );
    }
    viewAllUsers(): void {
        this.userService.getUsers().subscribe(
            users => {
                for (let user of users) {
                    let vuser: ViewUser;
                    vuser = new ViewUser(user.FirstName,user.LastName,user.Employee_ID,user.User_ID);
                    this.listViewUser.push(vuser);
                }
            },
            error => this.errorMessage = <any>error
        );
    }
    ngOnInit(): void {
        console.log('Init method is fired from User Component');
        this.viewAllUsers();
    }
}