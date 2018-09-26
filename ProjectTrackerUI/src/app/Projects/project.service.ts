import { Injectable } from "@angular/core";
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Project, ProjectAndStatus, ViewProject } from "src/app/Projects/project";
import { Observable, throwError } from "rxjs";
import { tap, catchError } from "rxjs/Operators";

@Injectable({
    providedIn: 'root'
})
export class ProjectService {
    private createProjectUrl = "http://localhost/ProjectTrackerAPI/api/projects/newproject";
    private viewProjectAndStatusUrl = "http://localhost/ProjectTrackerAPI/api/projects/viewprojects";
    private viewProjectsUrl = "http://localhost/ProjectTrackerAPI/api/projects/all";
    constructor(private http: HttpClient) { }
    createProject(projectData: Project): Observable<string> {
        return this.http.post<string>(this.createProjectUrl, projectData).pipe(
            tap(res => {
                console.log(res);
            }),
            catchError(this.handleError)
        );
    }
    viewProjectsAndStatus():Observable<ProjectAndStatus[]>{
        return this.http.get<ProjectAndStatus[]>(this.viewProjectAndStatusUrl).pipe(
            tap(data=>{
                console.log('All Projects And Status :'+JSON.stringify(data));
            }),
            catchError(this.handleError)
        );
    }
    searchProjects():Observable<ViewProject[]>{
        return this.http.get<ViewProject[]>(this.viewProjectsUrl).pipe(
            tap(data=>{
                console.log('All Projects :'+JSON.stringify(data));
            }),
            catchError(this.handleError)
        );
    }
    private handleError(err: HttpErrorResponse) {
        let errorMessage = '';
        if (err.error instanceof ErrorEvent) {
            errorMessage = `An Error Occurred: ${err.error.message}`;
        }
        else {
            errorMessage = `Server Returned code: ${err.status},error message is:${err.message}`;
        }
        console.error(errorMessage);
        return throwError(errorMessage);
    }
}