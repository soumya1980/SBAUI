import { Component } from "@angular/core";
import { TaskService } from "src/app/Tasks/task.service";
import { ViewTask } from "src/app/Tasks/task";
import { OnInit } from "@angular/core/src/metadata/lifecycle_hooks";

@Component({
    templateUrl:'./viewtask.component.html'
})
export class ViewTaskComponent implements OnInit{
    listViewTasks: ViewTask[] = [];
    errorMessage: string;
constructor(private taskService:TaskService){}
viewAllTasks(): void {
    this.taskService.viewTasks().subscribe(
        tasks => {
            console.log('Service Fetched All Tasks' + JSON.stringify(tasks));
            if (tasks.length > 1) {
                for (let task of tasks) {
                    let vtask:ViewTask;
                    if (task.ParentTask==task.TaskName) {
                        vtask = new ViewTask(task.TaskID,task.TaskName,task.StartDate,task.EndDate,task.Priority,
                        task.Status,task.ParentTaskID,'',task.ProjectID,task.ProjectDesc);
                        this.listViewTasks.push(vtask);
                    }
                    else{
                        vtask = new ViewTask(task.TaskID,task.TaskName,task.StartDate,task.EndDate,task.Priority,
                            task.Status,task.ParentTaskID,task.ParentTask,task.ProjectID,task.ProjectDesc);
                            this.listViewTasks.push(vtask);
                    }
                }
            }
            
            console.log('Component Built TaskList' + JSON.stringify(this.listViewTasks));
        },
        error => this.errorMessage = <any>error
    );
}
ngOnInit(): void {
    console.log('Init method is fired from ViewAllTask Component');
    this.viewAllTasks();
}
}