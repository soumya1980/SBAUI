import { Pipe } from "@angular/core";
import { PipeTransform } from "@angular/core";
import { User } from "src/app/Users/User";

@Pipe({
    name: 'nonManagers'
})
export class NonManagerFilter implements PipeTransform {
    nonManagerList :User[]=[];
    //Take the User object find if IsMgr = true.
    //If true then remove it as part of filtering
    transform(value: User[], character: boolean): User[] {
       for(let usr of value){
        if(usr.IsMgr==character){
            //if character set to false, then pull the user
            let filterUser=new User(usr.User_ID,usr.FirstName,usr.LastName,usr.Employee_ID)
            this.nonManagerList.push(filterUser);
        }
       }
        return this.nonManagerList;
    }
}