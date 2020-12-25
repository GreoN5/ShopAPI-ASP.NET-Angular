import { Component, OnInit } from '@angular/core';
import { AdminService } from 'src/app/shared/admin.service';

@Component({
  selector: 'app-create-product',
  templateUrl: './create-product.component.html',
  styleUrls: ['./create-product.component.css']
})
export class CreateProductComponent implements OnInit {

  constructor(public adminService: AdminService) { }

  ngOnInit(): void {
    this.getProductCategories()
    this.adminService.createModelProduct.reset()
  }

  getProductCategories() {
    this.adminService.getAllProductCategories().subscribe(
      data => {
        this.adminService.productCategories = data
      }, error => {
        console.log(error)
      }
    )
  }

  submit() {
    this.adminService.createNewProduct().subscribe(
      response => {
        this.adminService.createModelProduct.reset()
      }, error => {
        console.log(error)
      }
    )
  }

}
