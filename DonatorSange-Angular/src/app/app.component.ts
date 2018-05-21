import { Component } from '@angular/core';
import { CommunicationService } from './services/communication.service';
import { UserService } from './services/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'], 
  providers:[CommunicationService]
})
export class AppComponent {
  title = 'app';
  isAuthenticated;
  constructor(private router: Router, private communicationService:CommunicationService){
    communicationService.notify$.subscribe(()=>{
      console.log('semnal primit');
    });
  }
  changeOfRoutes(){
    this.isAuthenticated = localStorage.getItem("auth_token") ? true: false;
  }
  logout(){
    localStorage.removeItem('auth_token');
    this.router.navigateByUrl("/");
  }
}
