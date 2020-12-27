import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AdminService } from 'src/app/shared/admin.service';

@Component({
  selector: 'app-show-remove-product',
  templateUrl: './show-remove-product.component.html',
  styleUrls: ['./show-remove-product.component.css']
})
export class ShowRemoveProductComponent implements OnInit {

  constructor(public adminService: AdminService, private router: Router) { }

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

  editProduct(productID) {
    this.router.navigateByUrl('admin/edit/' + productID)
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
