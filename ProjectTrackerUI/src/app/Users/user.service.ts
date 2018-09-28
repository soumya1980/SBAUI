import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { User } from "src/app/Users/User";
import{Observable} from "rxjs";
import{tap,catchError} from "rxjs/Operators";
import { HttpErrorResponse } from "@angular/common/http/src/response";
import { throwError } from "rxjs/internal/observable/throwError";
import {Headers} from "@angular/http";
import { RequestOptions } from "@angular/http";
import { RequestMethod } from "@angular/http";
import { CreateUser, ViewUser } from "src/app/Users/createuser";

@Injectable({
    providedIn:'root'
})
export class UserService{
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
    private getusersUrl="http://localhost/ProjectTrackerAPI/api/user/all";
    private createUserUrl="http://localhost/ProjectTrackerAPI/api/user/newuser";
    private patchUserUrl="http://localhost/ProjectTrackerAPI/api/user/patchuser/";
    private deleteUserUrl="http://localhost/ProjectTrackerAPI/api/user/deleteuser/";
    constructor(private http:HttpClient){}
    getUsers():Observable<User[]>{
        return this.http.get<User[]>(this.getusersUrl).pipe(
            tap(data=>{
                console.log('All Users :'+JSON.stringify(data));
            }),
            catchError(this.handleError)
        );
    }
    createUser(userData:CreateUser):Observable<string>{
        return this.http.post<string>(this.createUserUrl,userData).pipe(
            tap(res=>{
            console.log(res);
        }),
        catchError(this.handleError)
    );
    }
    patchUser(id:any,userData:ViewUser):Observable<string>{
        return this.http.put<string>(this.patchUserUrl+id,userData).pipe(
            tap(res=>{
            console.log(res);
        }),
        catchError(this.handleError)
    );
    }
    deleteUser(userid:string):Observable<string>{
        return this.http.delete<string>(this.deleteUserUrl+userid).pipe(
            tap(res=>{
            console.log(res);
        }),
        catchError(this.handleError)
    );
    }
}