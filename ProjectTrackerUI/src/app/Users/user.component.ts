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
    constructor(private userService: UserService) {

    }
    createUser(): void {
        console.log('User clicked');
        let userData=new CreateUser("Ashok","Mounth",105);
        this.userService.createUser(userData).subscribe(
            res => {
            console.log('User Created' + JSON.stringify(res));
        },
        error=>this.errorMessage=<any>error
    );
    }
}