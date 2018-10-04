import {of, Observable } from "rxjs";
import { HttpErrorResponse } from "@angular/common/http";
import { ProjectService } from "./project.service";
import { ProjectAndStatus, ViewProject, Project, UserProject } from "./project";
import { TestBed } from "@angular/core/testing";
import { HttpModule } from "@angular/http";
import { MockBackend, MockConnection } from '@angular/http/testing';
import { Http, BaseRequestOptions, Response, ResponseOptions, RequestMethod } from '@angular/http';

describe('ProjectServiceTest',()=>{
    let projectservice:ProjectService;
    let httpClientSpy:{get:jasmine.Spy};
    let mockService={
        createProject:jasmine.createSpy('createProject').and.returnValue(of('1'))
    }
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
    // beforeEach(() => {
    //     TestBed.configureTestingModule({
    //       imports: [HttpModule],
    //       providers: [{
    //         provide: ProjectService,
    //         useValue: mockService
    //       }]
    //     });
    //   });
   
    xit('Add Project',()=>{
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


// import {of, Observable } from "rxjs";
// //import 'rxjs/Rx';
// import { HttpErrorResponse } from "@angular/common/http";
// import { ProjectService } from "./project.service";
// import { ProjectAndStatus, ViewProject, Project, UserProject } from "./project";
// import { TestBed, async } from "@angular/core/testing";
// import { HttpModule, XHRBackend } from "@angular/http";
// import { MockBackend, MockConnection } from '@angular/http/testing';
// import { Http, BaseRequestOptions, Response, ResponseOptions, RequestMethod } from '@angular/http';
// import { FormsModule } from "@angular/forms";

// describe('ProjectService', () => {
//     beforeEach(async(() => {
//       TestBed.configureTestingModule({
//         providers: [
//           ProjectService,
//           MockBackend,
//           BaseRequestOptions,
//           {
//             provide: Http,
//             deps: [MockBackend, BaseRequestOptions],
//             useFactory:
//               (backend: XHRBackend, defaultOptions: BaseRequestOptions) => {
//                   return new Http(backend, defaultOptions);
//               }
//            }
//         ],
//         imports: [
//           FormsModule,
//           HttpModule
//         ]
//       });
   
//       TestBed.compileComponents();
//     }));
   
//     // tests here
   
//   });
