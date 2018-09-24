import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './shared/header.html',
  /*template:`
  <ul class='nav navbar-nav'>
  <li><a>Projects</a></li>
  <li><a>Tasks</a></li>
  <li><a>Users</a></li>
  <li><a>View Tasks</a></li>
  </ul>
  <pm-project></pm-project>
  `,*/
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ProjectTracker';
  searchText :string;
}
