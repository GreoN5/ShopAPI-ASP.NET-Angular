import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AdminService } from 'src/app/shared/admin.service';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.css']
})
export class EditProductComponent implements OnInit {

  constructor(private adminService: AdminService, private router: ActivatedRoute) { }

  productID;
  productEdit;

  ngOnInit(): void {
    this.products()

    this.router.paramMap.subscribe(paramMap => {
      this.productID = paramMap.get('id')
      this.editedProduct(this.productID)
    })
  }

  editedProduct(id) {
    this.adminService.editProduct(id).subscribe(
      product => {
        for (let i = 0; i < this.adminService.allProducts.length; i++) {
          if (this.adminService.allProducts[i].id === id) {
            localStorage.setItem('productEdit', product.toString())

            break
          }
        }
      }, error => {
        console.log(error)
      }
    )
  }

  products() {
    this.adminService.getAllProducts().subscribe(
      data => {
        this.adminService.allProducts = data
      }, error => {
        console.log(error)
      }
    )
  }

}
