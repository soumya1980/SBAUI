import { TaskService } from "./task.service";
import { ViewTask } from "./task";
import {of, Observable } from "rxjs";
import { HttpErrorResponse } from "@angular/common/http";

describe('TaskServiceTest',()=>{
    let taskservice:TaskService;
    let httpClientSpy:{get:jasmine.Spy};
    beforeEach(()=>{
        httpClientSpy=jasmine.createSpyObj('HttpClient',['get']);
        taskservice=new TaskService(<any>httpClientSpy);
    });
    it('Should return expected Tasks',()=>{
        const expectedTask:ViewTask[]=[];
        httpClientSpy.get.and.returnValues(of(expectedTask));
        taskservice.viewTasks().subscribe(tasks=>expect(tasks).toEqual(expectedTask,'expected Tasks'),fail);
        expect(httpClientSpy.get.calls.count()).toBe(1,'One Call');
    })
    xit('should return a service error',()=>{
        const errorResponse=new HttpErrorResponse({
            error:'404 error',
            status:404,
            statusText:'Not Found'
        });
        httpClientSpy.get.and.returnValues(of(errorResponse));
        taskservice.viewTasks().subscribe(
            tasks=>fail('Expected Error'),
            error=>expect(error.message).toContain('404 error')
            );
    })
    
})