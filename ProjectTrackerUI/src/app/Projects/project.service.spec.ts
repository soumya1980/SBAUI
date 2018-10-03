
import {of, Observable } from "rxjs";
import 'rxjs/Rx';
import { HttpErrorResponse } from "@angular/common/http";
import { ProjectService } from "./project.service";
import { ProjectAndStatus, ViewProject, Project, UserProject } from "./project";

describe('ProjectServiceTest',()=>{
    let projectservice:ProjectService;
    let httpClientSpy:{get:jasmine.Spy};
    beforeEach(()=>{
        httpClientSpy=jasmine.createSpyObj('HttpClient',['get','post','put']);
        projectservice=new ProjectService(<any>httpClientSpy);
    });
    it('Should return expected Tasks and status',()=>{
        const expectedProject:ProjectAndStatus[]=[];
        httpClientSpy.get.and.returnValues(of(expectedProject));
        projectservice.viewProjectsAndStatus().subscribe(projects=>expect(projects).toEqual(expectedProject,'expected Projects and Status'),fail);
        expect(httpClientSpy.get.calls.count()).toBe(1,'One Call');
    })
    it('Should return expected Projects',()=>{
        const expectedProjects:ViewProject[]=[];
        httpClientSpy.get.and.returnValues(of(expectedProjects));
        projectservice.searchProjects().subscribe(projects=>expect(projects).toEqual(expectedProjects,'expected Projects'),fail);
        expect(httpClientSpy.get.calls.count()).toBe(1,'One Call');
    })
    xit('should return a service error',()=>{
        const errorResponse=new HttpErrorResponse({
            error:'404 error',
            status:404,
            statusText:'Not Found'
        });
        httpClientSpy.get.and.returnValues(of(errorResponse));
        projectservice.viewProjectsAndStatus().subscribe(
            tasks=>fail('Expected Error'),
            error=>expect(error.message).toContain('404 error')
            );
    })
    it('Add Project',()=>{
        const usrProject:UserProject={ProjectDesc:'Test',StartDt:'',EndDt:'',Priority:1};
        const projectData:Project={employyeId:1,userProject:usrProject};
        
        projectservice.createProject(projectData).subscribe(
            p=>{
                expect(p).toEqual("1");
                //done();
            }
        );
    })
})