import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css'],
  providers:[UserService]
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
    if (!name) {
      this.invalid = true;
      return;
    }
    if (!password) {
      this.invalid = true;
      return;
    }
    this.invalid = false;
    this.userService.tryLogin(name, password)
      .then(authenticated => {

        this.invalid = !authenticated;
        if (authenticated) {
          let id=localStorage.getItem("auth_id");
          this.userService.getUser(id).then(user => {
            if (user.role.name == "Donor") {
              this.router.navigateByUrl("donor-page");
            }
            if (user.role.name == "Doctor") {
              this.router.navigateByUrl("doctor-page");
            }
            if(user.role.name=="Asistant"){
              this.router.navigateByUrl("asistant-page");
            }
            localStorage.setItem('myUser',JSON.stringify(user));
          }
          )
        }
      });
  }

  goToRegister(){
    this.router.navigate(['/register'])
  }




}
