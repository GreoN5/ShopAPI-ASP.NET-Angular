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

  usernameInUseMsg: boolean
  emailInUseMsg: boolean
  bankAccountNumberInUseMsg: boolean
  registrationSuccess: boolean

  ngOnInit(): void {
    this.userService.registerModel.reset()
  }

  submit() {
    this.userService.register().subscribe(
      (response: any) => {
        this.registrationSuccess = true
        this.userService.registerModel.reset()
      }, error => {
        localStorage.setItem('error', error)
        console.log(error)

        if (error.status === 409) {
          this.usernameInUseMsg = true
        } else if (error.status === 410) {
          this.emailInUseMsg = true
        } else if (error.status === 411) {
          this.bankAccountNumberInUseMsg = true
        }
      })
  }
}
