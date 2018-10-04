import { ProjectService } from "../Projects/project.service";
import { TaskComponent } from "./task.component";
import { UserService } from "../Users/user.service";
import { TaskService } from "./task.service";
import { TestBed } from "@angular/core/testing";
import { of } from "rxjs";
import { ViewProject } from "../Projects/project";
import { User } from "../Users/User";
import { ParentTask } from "./task";

describe('Task Component Test',()=>{
    let comp:TaskComponent;
    let projSrvcSpy:jasmine.SpyObj<ProjectService>;
    let usrSrvcSpy:jasmine.SpyObj<UserService>;
    let taskSrvcSpy:jasmine.SpyObj<TaskService>;
    beforeEach(()=>{
        const spy=jasmine.createSpyObj('ProjectService',['searchProjects']);
        const spyuser=jasmine.createSpyObj('UserService',['getUsers']);
        const spytask=jasmine.createSpyObj('TaskService',['viewParentTasks']);
        TestBed.configureTestingModule({
            //provide the component under test and dependent service
            providers:[
                TaskComponent,
            [
                {provide:ProjectService,useValue:spy},
                {provide:UserService,useValue:spyuser},
                {provide:TaskService,useValue:spytask}
            ]
            ]
        });
        comp=TestBed.get(TaskComponent);
        projSrvcSpy=TestBed.get(ProjectService);
        usrSrvcSpy=TestBed.get(UserService);
        taskSrvcSpy=TestBed.get(TaskService);
    });
    //it here
    it('Should have No Parent tasks',()=>{
        expect(comp.listParentTasks.length).toBe(0);
    })
    it('SHould return list tasks',()=>{
        const listprojects:ViewProject[]=[];
        const listuser:User[]=[];
        const listParentTasks:ParentTask[]=[];
        projSrvcSpy.searchProjects.and.returnValues(of(listprojects));
        usrSrvcSpy.getUsers.and.returnValues(of(listuser));
        taskSrvcSpy.viewParentTasks.and.returnValues(of(listParentTasks));
        comp.ngOnInit();
        expect(comp.listProjects.length).toBe(0);
        expect(comp.listParentTasks.length).toBe(0);
    })
})