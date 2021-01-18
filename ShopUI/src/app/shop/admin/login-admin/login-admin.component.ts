import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-login-admin',
  templateUrl: './login-admin.component.html',
  styleUrls: ['./login-admin.component.css']
})
export class LoginAdminComponent implements OnInit {

  loginModel = {
    Username: '',
    Password: ''
  }

  constructor(public userService: UserService, private router: Router) { }

  ngOnInit(): void {
    if (localStorage.getItem('token') !== null) {
      this.router.navigateByUrl('/admin/home');
    }
  }

  submit(loginForm: NgForm) {
    this.userService.login(loginForm.value).subscribe(
      (response: any) => {
        localStorage.setItem('token', response.authToken);
        localStorage.setItem('role', response.role);

        this.router.navigateByUrl('/admin/home');
      }, error => {
        console.log(error);
      }
    )
  }

}