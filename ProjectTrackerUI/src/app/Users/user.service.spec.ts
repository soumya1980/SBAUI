import { UserService } from "./user.service";
import { User } from "./User";
import {of, Observable } from "rxjs";
import { HttpErrorResponse } from "@angular/common/http";

describe('UserServiceTest',()=>{
    let userservice:UserService;
    let httpClientSpy:{get:jasmine.Spy};
    beforeEach(()=>{
        httpClientSpy=jasmine.createSpyObj('HttpClient',['get']);
        userservice=new UserService(<any>httpClientSpy);
    });
    it('Should return expected Users',()=>{
        const expectedUser:User[]=[];
        httpClientSpy.get.and.returnValues(of(expectedUser));
        userservice.getUsers().subscribe(users=>expect(users).toEqual(expectedUser,'expected users'),fail);
        expect(httpClientSpy.get.calls.count()).toBe(1,'One Call');
    })
    xit('should return a service error',()=>{
        const errorResponse=new HttpErrorResponse({
            error:'404 error',
            status:404,
            statusText:'Not Found'
        });
        httpClientSpy.get.and.returnValues(of(errorResponse));
        userservice.getUsers().subscribe(
            users=>fail('Expected Error'),
            error=>expect(error.message).toContain('404 error')
            );
    })
    it('Create User',()=>{
        
    })
})