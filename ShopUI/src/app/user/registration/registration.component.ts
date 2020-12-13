import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  constructor(public userService: UserService, private router: Router) { }

  ngOnInit(): void {
    this.userService.registerModel.reset()
  }

  submit() {
    this.userService.register().subscribe(
      response => {
        this.userService.registerModel.reset()
      }, error => {
        console.log(error)

        if (error.status === 409) {
          alert(`Username ${this.userService.registerModel.value.Username} already exists! Try another one.`)
        } else if (error.status === 410) {
          alert(`Email ${this.userService.registerModel.value.EmailAddress} already exists! Try another one.`)
        } else if (error.status === 411) {
          alert(`Bank account number ${this.userService.registerModel.value.BankAccountNumber} already exists! Try another one.`)
        }
      })
  }

  getError() {
    return localStorage.getItem('error')
  }
}
