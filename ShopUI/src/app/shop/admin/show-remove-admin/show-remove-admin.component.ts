import { Component, OnInit } from '@angular/core';
import { AdminService } from 'src/app/shared/admin.service';

@Component({
  selector: 'app-show-remove-admin',
  templateUrl: './show-remove-admin.component.html',
  styleUrls: ['./show-remove-admin.component.css']
})
export class ShowRemoveAdminComponent implements OnInit {

  constructor(public adminService: AdminService) { }

  ngOnInit(): void {
    this.showAdmins();
  }

  showAdmins() {
    this.adminService.getAllAdmins().subscribe(
      data => {
        this.adminService.admins = data;
      }, error => {
        console.log(error);
      }
    )
  }

  deleteAdmin(username) {
    this.adminService.removeAdmin(username).subscribe(
      data => {
        for (let i = 0; i < this.adminService.admins.length; i++) {
          if (this.adminService.admins[i].username === username) {
            this.adminService.admins.splice(i, 1);

            break;
          }
        }
      }, error => {
        console.log(error);
      }
    )
  }

}
