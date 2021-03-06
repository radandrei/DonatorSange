import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { Router, ActivatedRoute } from '@angular/router';
import { UserService } from '../services/user.service';
import { User } from '../models/user';
import { CommunicationService } from '../services/communication.service';


@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css'],
  providers: [UserService, CommunicationService]
})

export class LoginFormComponent {

  public invalid = false;
  user: User;


  constructor(private router: Router,
    private route: ActivatedRoute, private userService: UserService, private communicationService:CommunicationService) {
    localStorage.removeItem("myUser");
  }

  login(name: string, password: string): void {
    let authenticated;

    if (!name) {
      this.invalid = true;
      return;
    }
    if (!password) {
      this.invalid = true;
      return;
    }

    this.invalid = false;

    this.userService.tryLogin(name, password).subscribe(response => {
      localStorage.setItem('auth_token', response.auth_token);
      localStorage.setItem('auth_id', response.id);
      let id = localStorage.getItem("auth_id");
      this.userService.getUser(id).then(user => {
        console.log(user.role.name)
        if (user.role.name == "Donor") {
          this.router.navigate(["/donor"]);
        }
        if (user.role.name == "Medic") {
          this.router.navigateByUrl("doctor");
        }
        if (user.role.name == "Staff") {
          this.router.navigateByUrl("medicalstaff");
        }
        localStorage.setItem('myUser', JSON.stringify(user));
        //this.communicationService.notify();
      });
    },
      error => {
        this.invalid = true;
      });
  }


  goToRegister() {
    this.router.navigate(['/register'])
  }
}
