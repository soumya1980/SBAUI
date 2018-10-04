import { UserService } from "./user.service";
import { TestBed } from "@angular/core/testing";
import { UserComponent } from "./user.component";
import { User } from "./User";
import { of } from "rxjs";
import { ProjectService } from "../Projects/project.service";

describe('User Component Test',()=>{
    let usrService:UserService;
    let comp:UserComponent;
    let userSrvc:UserService;
    let usrSrvcSpy:jasmine.SpyObj<UserService>;
    
    beforeEach(()=>{
        const spyusersrvc=jasmine.createSpyObj('UserService',['getUsers']);
                TestBed.configureTestingModule({
            //provide the component under test and dependent service
            providers:[
                UserComponent,
                {provide:UserService,useValue:spyusersrvc}
            ]
        });
        comp=TestBed.get(UserComponent);
        usrSrvcSpy=TestBed.get(UserService);
        
    });
    //it here
    it('Should have no users',()=>{
        expect(comp.listFilteredUser.length).toBe(0);
    })
    it('SHould return listusers',()=>{
        const listUsers:User[]=[{"User_ID":1,"FirstName":"S","LastName":"M",Employee_ID:100,"IsMgr":false,"ProjectId":1,"TaskId":1}];
        usrSrvcSpy.getUsers.and.returnValues(of(listUsers));
        comp.ngOnInit();
        expect(comp.listViewUser.length).toBe(1);
    })
})