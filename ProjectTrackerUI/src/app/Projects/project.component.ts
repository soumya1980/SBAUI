import { Component } from "@angular/core";
import { UserService } from "src/app/Users/user.service";
import { OnInit } from "@angular/core/src/metadata/lifecycle_hooks";
import { User } from "src/app/Users/User";

@Component(
    {
        templateUrl: './project.component.html'
    }
)
export class ProjectComponent implements OnInit {
    listUsers: User[] = [];
    errorMessage: string;
    constructor(private userService: UserService) {
        console.log('constructor is fired from Project Component');
    }
    searchUsers(): void {
        this.userService.getUsers().subscribe(
            users => {
                console.log('Service Fetched Users' + JSON.stringify(users));
                if (users.length > 1) {
                    for (let user of users) {
                        let fuser: User;
                        //Pull Non Manager Users
                        if (user.IsMgr == false && (user.FirstName !=null && user.LastName !=null)) {
                            fuser = new User(user.User_ID, user.FirstName, user.LastName, user.Employee_ID);
                            this.listUsers.push(fuser);
                        }
                    }
                }
                else {
                    let fuser: User;
                    if (users["IsMgr"] == false) {
                        fuser = new User(users["User_ID"], users["FirstName"], users["LastName"],
                            users["Employee_ID"]);
                        this.listUsers.push(fuser);
                    }
                }
                console.log('Component Built Users' + JSON.stringify(this.listUsers));
            },
            error => this.errorMessage = <any>error
        );
    }
    ngOnInit(): void {
        console.log('Init method is fired from Project Component');
        this.searchUsers();
    }
}