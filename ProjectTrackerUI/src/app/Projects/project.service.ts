import { Injectable } from "@angular/core";
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Project } from "src/app/Projects/project";
import { Observable, throwError } from "rxjs";
import { tap, catchError } from "rxjs/Operators";

@Injectable({
    providedIn: 'root'
})
export class ProjectService {
    private createProjectUrl = "http://localhost/ProjectTrackerAPI/api/projects/newproject";
    constructor(private http: HttpClient) { }
    createProject(projectData: Project): Observable<string> {
        return this.http.post<string>(this.createProjectUrl, projectData).pipe(
            tap(res => {
                console.log(res);
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