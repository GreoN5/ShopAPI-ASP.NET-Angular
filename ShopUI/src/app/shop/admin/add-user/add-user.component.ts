import { Component, OnInit } from '@angular/core';
import { AdminService } from 'src/app/shared/admin.service';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent implements OnInit {

  constructor(private adminService: AdminService) { }

  ngOnInit(): void {
  }

  submit() {
    this.adminService.addNewUser().subscribe(
      response => {
        this.adminService.createModelUser.reset()
      }, error => {
        console.log(error)
      }
    )
  }

}
