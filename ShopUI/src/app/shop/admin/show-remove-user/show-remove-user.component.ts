import { Component, OnInit } from '@angular/core';
import { AdminService } from 'src/app/shared/admin.service';

@Component({
  selector: 'app-show-remove-user',
  templateUrl: './show-remove-user.component.html',
  styleUrls: ['./show-remove-user.component.css']
})
export class ShowRemoveUserComponent implements OnInit {

  constructor(public adminService: AdminService) { }

  ngOnInit(): void {
    this.showUsers()
  }

  showUsers() {
    this.adminService.getAllRegisteredUsers().subscribe(
      data => {
        this.adminService.registeredUsers = data
      }, error => {
        console.log(error)
      }
    )
  }

  deleteUser(username) {
    this.adminService.removeUser(username).subscribe(
      data => {
        for (let i = 0; i < this.adminService.registeredUsers.length; i++) {
          if (this.adminService.registeredUsers[i].username === username) {
            this.adminService.registeredUsers.splice(i, 1)

            break;
          }
        }
      }, error => {
        console.log(error)
      }
    )
  }
}
