import { ProjectService } from "./project.service";
import { ProjectComponent } from "./project.component";
import { TestBed } from "@angular/core/testing";
import { ProjectAndStatus } from "./project";
import { of } from "rxjs";
import { UserService } from "../Users/user.service";
import { User } from "../Users/User";

describe('Project Component Test',()=>{
    let projectService:ProjectService;
    let comp:ProjectComponent;
    let projectSrvc:ProjectService;
    let projSrvcSpy:jasmine.SpyObj<ProjectService>;
    let usrSrvcSpy:jasmine.SpyObj<UserService>;
    beforeEach(()=>{
        const spy=jasmine.createSpyObj('ProjectService',['viewProjectsAndStatus']);
        const spyuser=jasmine.createSpyObj('UserService',['getUsers']);
        TestBed.configureTestingModule({
            //provide the component under test and dependent service
            providers:[
                ProjectComponent,
                [{provide:ProjectService,useValue:spy},{provide:UserService,useValue:spyuser}]
            ]
        });
        comp=TestBed.get(ProjectComponent);
        projSrvcSpy=TestBed.get(ProjectService);
        usrSrvcSpy=TestBed.get(UserService);
    });
    //it here
    it('Should have No Projects',()=>{
        expect(comp.listProjects.length).toBe(0);
    })
    it('SHould return listusers',()=>{
        const listprojectsandstatus:ProjectAndStatus[]=[];
        const listuser:User[]=[];
        projSrvcSpy.viewProjectsAndStatus.and.returnValues(of(listprojectsandstatus));
        usrSrvcSpy.getUsers.and.returnValues(of(listuser));
        comp.ngOnInit();
        expect(comp.listProjects.length).toBe(0);
    })
})