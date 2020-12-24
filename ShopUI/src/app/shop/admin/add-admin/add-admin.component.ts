import { Component, OnInit } from '@angular/core';
import { AdminService } from 'src/app/shared/admin.service';

@Component({
  selector: 'app-add-admin',
  templateUrl: './add-admin.component.html',
  styleUrls: ['./add-admin.component.css']
})
export class AddAdminComponent implements OnInit {

  constructor(private adminService: AdminService) { }

  ngOnInit(): void {
  }

  submit() {
    this.adminService.addNewAdmin().subscribe(
      response => {
        this.adminService.createModelAdmin.reset()
      }, error => {
        console.log(error)
      }
    )
  }

}
