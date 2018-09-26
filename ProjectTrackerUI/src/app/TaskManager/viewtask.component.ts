import { Component } from "@angular/core";
import { TaskService } from "src/app/Tasks/task.service";
import { ViewTask } from "src/app/Tasks/task";
import { OnInit } from "@angular/core/src/metadata/lifecycle_hooks";

@Component({
    templateUrl: './viewtask.component.html'
})
export class ViewTaskComponent implements OnInit {
    searchProjectText: string;
    listViewTasks: ViewTask[] = [];
    errorMessage: string;
    listFilteredProjctTask: ViewTask[] = [];
    constructor(private taskService: TaskService) {
        console.log('Constructor Trigerred');
        this.listFilteredProjctTask = this.listViewTasks;
    }
    PerformFilter(): ViewTask[] {
        let filterBy = this.searchProjectText.toLocaleLowerCase();
        this.listFilteredProjctTask= this.listViewTasks.filter((task: ViewTask) => task.ProjectDesc.toLocaleLowerCase().indexOf(filterBy) !== -1);
        return this.listFilteredProjctTask;
    }
    viewAllTasks(): void {
        this.taskService.viewTasks().subscribe(
            tasks => {
                if (tasks.length > 1) {
                    for (let task of tasks) {
                        let vtask: ViewTask;
                        if (task.ParentTask == task.TaskName) {
                            vtask = new ViewTask(task.TaskID, task.TaskName, task.StartDate, task.EndDate, task.Priority,
                                task.Status, task.ParentTaskID, '', task.ProjectID, task.ProjectDesc);
                            this.listViewTasks.push(vtask);
                        }
                        else {
                            vtask = new ViewTask(task.TaskID, task.TaskName, task.StartDate, task.EndDate, task.Priority,
                                task.Status, task.ParentTaskID, task.ParentTask, task.ProjectID, task.ProjectDesc);
                            this.listViewTasks.push(vtask);
                        }
                    }
                }
            },
            error => this.errorMessage = <any>error
        );
    }
    ngOnInit(): void {
        console.log('Init method is fired from ViewAllTask Component');
        this.viewAllTasks();
    }
}