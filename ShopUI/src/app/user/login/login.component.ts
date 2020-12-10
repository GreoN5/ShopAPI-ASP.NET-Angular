import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginModel = {
    Username: '',
    Password: ''
  }

  constructor(public userService: UserService, private router: Router) { }

  ngOnInit(): void {
    if (localStorage.getItem('token') !== null) {
      this.router.navigateByUrl('/home')
    }
  }

  onSubmit(loginForm: NgForm) {
    this.userService.login(loginForm.value).subscribe(
      (response: any) => {
        localStorage.setItem('loggedUser', loginForm.value.Username)
        localStorage.setItem('token', response.token)
        this.router.navigateByUrl('/home')
        console.log(localStorage)
      }, error => {
        console.log(error)
      }
    )
  }
}
