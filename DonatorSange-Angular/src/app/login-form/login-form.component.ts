import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { Router, ActivatedRoute } from '@angular/router';
import { UserService } from '../services/user.service';
import { User } from '../models/user';


@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css'],
  providers: [UserService]
})

export class LoginFormComponent {

  public invalid = false;
  user: User;


  constructor(private router: Router,
    private route: ActivatedRoute, private userService: UserService) {
    this.userService.tryLogOut();
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
        if (user.role.name == "Donor") {
          this.router.navigateByUrl("medicalstaff");
        }
        if (user.role.name == "Doctor") {
          this.router.navigateByUrl("doctor");
        }
        if (user.role.name == "MedicalStaff") {
          this.router.navigateByUrl("medicalstaff");
        }
        localStorage.setItem('myUser', JSON.stringify(user));
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
