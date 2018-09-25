import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {RouterModule} from '@angular/router';
import { AppComponent } from './app.component';
import { ProjectComponent } from 'src/app/Projects/project.component';
import { TaskComponent } from './Tasks/task.component';
import { UserComponent } from './Users/user.component';
import { ViewTaskComponent } from './TaskManager/viewtask.component';
import { HttpClientModule } from '@angular/common/http';
import { NonManagerFilter } from 'src/app/Projects/user.filter';
import{FormsModule} from '@angular/forms';
@NgModule({
  declarations: [
    AppComponent,
    ProjectComponent,
    TaskComponent,
    UserComponent,
    ViewTaskComponent,
    NonManagerFilter
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(
      [
        {path : 'projects',component: ProjectComponent },
        {path : 'tasks',component: TaskComponent },
        {path : 'users',component: UserComponent },
        {path : 'taskmanager',component: ViewTaskComponent },
        {path : '', redirectTo : 'projects',pathMatch:'full' },
        {path : '**', redirectTo : 'taskmanager',pathMatch:'full' }
      ],{useHash:true})
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
