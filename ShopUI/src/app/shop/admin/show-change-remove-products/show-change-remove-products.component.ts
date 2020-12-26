import { Component, OnInit } from '@angular/core';
import { AdminService } from 'src/app/shared/admin.service';

@Component({
  selector: 'app-show-change-remove-products',
  templateUrl: './show-change-remove-products.component.html',
  styleUrls: ['./show-change-remove-products.component.css']
})
export class ShowChangeRemoveProductsComponent implements OnInit {

  constructor(public adminService: AdminService) { }

  ngOnInit(): void {
    this.showProducts()
  }

  showProducts() {
    this.adminService.getAllProducts().subscribe(
      data => {
        this.adminService.allProducts = data
      }, error => {
        console.log(error)
      }
    )
  }

  changeQuantityOfProduct(productName: string, quantity) {
    this.adminService.changeQuantityOfProduct(productName, quantity).subscribe(
      data => {
        for (let i = 0; i < this.adminService.allProducts.length; i++) {
          if (this.adminService.allProducts[i].name === productName) {
            this.adminService.allProducts[i].quantity = quantity

            break;
          }
        }
      }
    )
  }

  deleteProduct(productName) {
    this.adminService.removeProduct(productName).subscribe(
      data => {
        for (let i = 0; i < this.adminService.allProducts.length; i++) {
          if (this.adminService.allProducts[i].name === productName) {
            this.adminService.allProducts.splice(i, 1)

            break;
          }
        }
      }, error => {
        console.log(error)
      }
    )
  }
}
