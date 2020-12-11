import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  constructor(public userService: UserService) { }

  ngOnInit(): void {
    this.userService.registerModel.reset()
  }

  submit() {
    this.userService.register().subscribe(
      (response: any) => {
        this.userService.registerModel.reset()
      }, error => {
        console.log(error)
      })
  }
}
