import { Component } from "@angular/core";
import { CreateTask, Task, ParentTask } from "src/app/Tasks/task";
import { TaskService } from "src/app/Tasks/task.service";
import { UserService } from "src/app/Users/user.service";
import { User } from "src/app/Users/User";
import { OnInit } from "@angular/core/src/metadata/lifecycle_hooks";

@Component({
    templateUrl: './task.component.html'
})
export class TaskComponent implements OnInit {
    projectId: number;
    pTaskId: number;
    employeeId: number;
    taskName: string;
    stDt: string;
    endDt: string;
    priority: number;

    showParent: boolean;
    errorMessage: string;
    listUsers: User[] = [];
    listParentTasks: ParentTask[] = [];
    constructor(private taskService: TaskService, private userService: UserService) { }
    disableToggle() {
        this.showParent = !this.showParent;
        console.log(this.showParent);
    }
    createTask(): void {
        console.log('Task Create Button clicked');
        //If the End date is less than today's date then set the status as OPEN
        //Start Date must be >= Today and End Date must be <=Start Date
        let taskData: CreateTask;
        let status: string;
        if (!this.showParent) {
            taskData = new CreateTask(this.projectId, this.pTaskId, this.employeeId,
                new Task(this.taskName, this.stDt, this.endDt, this.priority, "Open"));
        }

        this.taskService.createTask(taskData).subscribe(
            res => {
                console.log('Task Created' + JSON.stringify(res));
            },
            error => this.errorMessage = <any>error
        );
    }
    createTaskAsParent(): void {
        console.log('Parent Task Create Button clicked');
        let taskData = new CreateTask(this.projectId, 0, this.employeeId,
            new Task(this.taskName, this.stDt, this.endDt, this.priority, "Open"));
        this.taskService.createTaskAsParent(taskData).subscribe(
            res => {
                console.log('Parent Task Created' + JSON.stringify(res));
            },
            error => this.errorMessage = <any>error
        );
    }
    searchUsers(): void {
        this.userService.getUsers().subscribe(
            users => {
                if (users.length > 1) {
                    for (let user of users) {
                        let fuser: User;
                        //Pull Non Manager Users
                        if (user.IsMgr == false && (user.FirstName != null && user.LastName != null)) {
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
            },
            error => this.errorMessage = <any>error
        );
    }
    searchParentTasks(): void {
        this.taskService.viewParentTasks().subscribe(
            tasks => {
                for (let task of tasks) {
                    let ftask: ParentTask;
                    ftask = new ParentTask(task.Parent_ID, task.Parent_Task);
                    this.listParentTasks.push(ftask);
                }
            },
            error => this.errorMessage = <any>error
        );
    }
    ngOnInit(): void {
        this.searchUsers();
        this.searchParentTasks();
    }
}