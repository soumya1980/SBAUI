import { Component } from "@angular/core";
import { CreateTask, Task } from "src/app/Tasks/task";
import { TaskService } from "src/app/Tasks/task.service";

@Component({
    templateUrl:'./task.component.html'
})
export class TaskComponent{
    errorMessage:string;
    constructor(private taskService:TaskService){}
    createTask(): void {
        console.log('Task Create Button clicked');
        let taskData=new CreateTask(1,1,3004,new Task("GIT Setup","09/25/2018","09/26/2018",3,"Open"));
        this.taskService.createTask(taskData).subscribe(
            res => {
            console.log('Task Created' + JSON.stringify(res));
        },
        error=>this.errorMessage=<any>error
    );
    }
}