import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AdminService } from 'src/app/shared/admin.service';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.css']
})
export class EditProductComponent implements OnInit {

  constructor(private adminService: AdminService, private router: ActivatedRoute, private fb: FormBuilder, private routerTo: Router) { }

  productID;
  productEdit = this.fb.group({
    Name: new FormControl('', [Validators.required]),
    Description: new FormControl(''),
    Price: new FormControl('', [Validators.required]),
    Quantity: new FormControl('', [Validators.required])
  });

  ngOnInit(): void {
    this.products()

    this.router.paramMap.subscribe(paramMap => {
      this.productID = paramMap.get('id')
      this.getProduct(this.productID)
    });

    let product = JSON.parse(localStorage.getItem('productEdit'));
    this.productEdit.patchValue({
      Name: product.name,
      Description: product.description,
      Price: product.price,
      Quantity: product.quantity
    });
  }

  getProduct(id) {
    this.adminService.getProduct(id).subscribe(
      product => {
        this.adminService.editedProduct = product;
        localStorage.setItem('productEdit', JSON.stringify(this.adminService.editedProduct));
      }, error => {
        console.log(error);
      }
    )
  }

  products() {
    this.adminService.getAllProducts().subscribe(
      data => {
        this.adminService.allProducts = data;
      }, error => {
        console.log(error);
      }
    )
  }

  submitChanges(id) {
    this.adminService.editProduct(id).subscribe(
      response => {
        this.routerTo.navigateByUrl('/admin/products');
        console.log(id);
      }, error => {
        console.log(error);
      }
    )

    //let product = this.adminService.allProducts.find(x => x.id == this.productID);
    //for (let i = 0; i < this.adminService.allProducts.length; i++) {
    //if (this.adminService.allProducts[i].id === this.productID) {
    //this.adminService.allProducts.splice(i, 1);
    //break;
    //}
    //}

    //product.id = this.productID;
    //product.name = this.productEdit.value.Name;
    //product.description = this.productEdit.value.Description;
    //product.price = this.productEdit.value.Price;
    //product.quantity = this.productEdit.value.Quantity;

    //this.adminService.allProducts.push(product);
  }

}
