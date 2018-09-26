import { Component } from "@angular/core";
import { CreateTask, Task } from "src/app/Tasks/task";
import { TaskService } from "src/app/Tasks/task.service";

@Component({
    templateUrl:'./task.component.html'
})
export class TaskComponent{
    projectId:number;
    pTaskId:number;
    employeeId:number;
    taskName:string;
    stDt:string;
    endDt:string;
    priority:number;
    
    showParent:boolean;
    errorMessage:string;
    constructor(private taskService:TaskService){}
    disableToggle(){
        this.showParent=!this.showParent;
        console.log(this.showParent);
    }
    createTask(): void {
        console.log('Task Create Button clicked');
        //If the End date is less than today's date then set the status as OPEN
        //Start Date must be >= Today and End Date must be <=Start Date
        let status:string;
        let taskData=new CreateTask(1,1,3004,
            new Task("GIT Setup","09/25/2018","09/26/2018",3,"Open"));
        this.taskService.createTask(taskData).subscribe(
            res => {
            console.log('Task Created' + JSON.stringify(res));
        },
        error=>this.errorMessage=<any>error
    );
    }
    createTaskAsParent(): void {
        console.log('Parent Task Create Button clicked');
        let taskData=new CreateTask(1,0,1,new Task("Form The Team","09/25/2018","11/26/2018",1,"Open"));
        this.taskService.createTaskAsParent(taskData).subscribe(
            res => {
            console.log('Parent Task Created' + JSON.stringify(res));
        },
        error=>this.errorMessage=<any>error
    );
    }
}