import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AdminService } from 'src/app/shared/admin.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  constructor(public adminService: AdminService, private router: Router) { }

  ngOnInit(): void {
  }

  productCategories() {
    this.adminService.getAllProductCategories().subscribe(
      data => {
        this.adminService.productCategories = data;
      }, error => {
        console.log(error);
      }
    )
  }

  logout() {
    localStorage.clear();
    this.router.navigateByUrl('/home')
  }

}
