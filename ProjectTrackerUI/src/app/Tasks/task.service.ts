import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { CreateTask } from "src/app/Tasks/task";
import { Observable, throwError } from "rxjs";
import { tap, catchError } from "rxjs/Operators";
import { HttpErrorResponse } from "@angular/common/http";

@Injectable({
    providedIn:'root'
})
export class TaskService{
    private createTaskUrl="http://localhost/ProjectTrackerAPI/api/tasks/newtask";
    private createTaskAsParentUrl="http://localhost/ProjectTrackerAPI/api/tasks/newtaskasparent";
    constructor(private http:HttpClient){}
    createTask(taskData:CreateTask):Observable<string>{
        return this.http.post<string>(this.createTaskUrl,taskData).pipe(
            tap(res=>{
            console.log(res);
        }),
        catchError(this.handleError)
    );
    }
    createTaskAsParent(taskData:CreateTask):Observable<string>{
        return this.http.post<string>(this.createTaskAsParentUrl,taskData).pipe(
            tap(res=>{
            console.log(res);
        }),
        catchError(this.handleError)
    );
    }
    private handleError(err:HttpErrorResponse) {
        let errorMessage='';
        if(err.error instanceof ErrorEvent){
            errorMessage=`An Error Occurred: ${err.error.message}`;
        }
        else{
            errorMessage=`Server Returned code: ${err.status},error message is:${err.message}`;
        }
        console.error(errorMessage);
        return throwError(errorMessage);
    }
}