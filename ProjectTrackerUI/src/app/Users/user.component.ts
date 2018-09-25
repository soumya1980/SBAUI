import { Component } from "@angular/core";
import { User } from "src/app/Users/User";
import { UserService } from "src/app/Users/user.service";
import { error } from "@angular/compiler/src/util";
import { CreateUser } from "src/app/Users/createuser";

@Component({
    templateUrl: './user.component.html'
})
export class UserComponent {
    errorMessage:string;
    firstName:string;
    lastName:string;
    employeeId:number;
    constructor(private userService: UserService) {

    }
    createUser(): void {
        console.log('User clicked');
        let userData=new CreateUser(this.firstName,this.lastName,this.employeeId);
        this.userService.createUser(userData).subscribe(
            res => {
            console.log('User Created' + JSON.stringify(res));
        },
        error=>this.errorMessage=<any>error
    );
    }
}