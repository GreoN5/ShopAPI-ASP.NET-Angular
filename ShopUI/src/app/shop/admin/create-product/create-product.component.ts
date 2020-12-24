import { Component, OnInit } from '@angular/core';
import { AdminService } from 'src/app/shared/admin.service';

@Component({
  selector: 'app-create-product',
  templateUrl: './create-product.component.html',
  styleUrls: ['./create-product.component.css']
})
export class CreateProductComponent implements OnInit {

  constructor(private adminService: AdminService) { }

  ngOnInit(): void {
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
