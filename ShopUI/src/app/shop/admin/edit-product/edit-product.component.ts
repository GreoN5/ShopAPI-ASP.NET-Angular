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
    this.router.paramMap.subscribe(paramMap => {
      this.productID = paramMap.get('id');
    });

    this.fillFormWithProduct(this.productID);
  }

  fillFormWithProduct(id) {
    this.adminService.getProduct(id).subscribe(
      product => {
        this.productEdit.patchValue({
          Name: product.name,
          Description: product.description,
          Price: product.price,
          Quantity: product.quantity
        });
      }, error => {
        console.log(error);
      }
    )
  }

  submitChanges(id) {
    let editedProduct = {
      name: this.productEdit.value.Name,
      description: this.productEdit.value.Description,
      price: this.productEdit.value.Price,
      quantity: this.productEdit.value.Quantity
    }

    this.adminService.editProduct(id, editedProduct).subscribe(
      (response: any) => {
        this.routerTo.navigateByUrl('/admin/products');
      }, error => {
        console.log(error);
      }
    )
  }

}
