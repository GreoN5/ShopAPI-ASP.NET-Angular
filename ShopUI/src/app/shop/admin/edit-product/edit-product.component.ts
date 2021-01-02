import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { AdminService } from 'src/app/shared/admin.service';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.css']
})
export class EditProductComponent implements OnInit {

  constructor(private adminService: AdminService, private router: ActivatedRoute, private fb: FormBuilder) { }

  productID;
  productEdit = this.fb.group({
    Name: new FormControl('', [Validators.required]),
    Description: new FormControl(''),
    Price: new FormControl('', [Validators.required]),
    Quantity: new FormControl('', [Validators.required])
  })

  ngOnInit(): void {
    this.products()

    this.router.paramMap.subscribe(paramMap => {
      this.productID = paramMap.get('id')
      this.editedProduct(this.productID)
    })

    let product = JSON.parse(localStorage.getItem('productEdit'))
    this.productEdit.patchValue({
      Name: product.name,
      Description: product.description,
      Price: product.price,
      Quantity: product.quantity
    })
  }

  editedProduct(id) {
    this.adminService.editProduct(id).subscribe(
      product => {
        for (let i = 0; i < this.adminService.allProducts.length; i++) {
          if (this.adminService.allProducts[i].id === id) {
            localStorage.setItem('productEdit', JSON.stringify(product))

            break;
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

  submitChanges() {

  }

}
