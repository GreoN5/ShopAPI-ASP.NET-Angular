import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  readonly ApiURL = 'https://localhost:44369' //URL to the server

  constructor(private http: HttpClient, private fb: FormBuilder) { }

  createModelUser = this.fb.group({
    Username: new FormControl('', [Validators.required]),
    Passwords: this.fb.group({
      Password: new FormControl('', [Validators.required, Validators.pattern('^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{6,}$')]),
      ConfirmPassword: new FormControl('', [Validators.required])
    }, {
      validators: this.comparePasswords
    }),
    EmailAddress: new FormControl('', [Validators.required, Validators.pattern(/\S+@\S+\.\S+/)]),
    Address: new FormControl(''),
    PhoneNumber: new FormControl('', [Validators.required, Validators.maxLength(10), Validators.minLength(10)]),
    BankAccountNumber: new FormControl('', [Validators.required, Validators.pattern('(^BG)([0-9]{2})([A-Z]{4})([0-9]{14}$)')])
  })

  createModelProduct = this.fb.group({
    Name: new FormControl('', [Validators.required]),
    Description: new FormControl(''),
    Price: new FormControl('', [Validators.required]),
    Quantity: new FormControl('', [Validators.required]),
    Category: new FormControl('', [Validators.required])
  })

  createModelAdmin = this.fb.group({
    Username: new FormControl('', [Validators.required]),
    Passwords: this.fb.group({
      Password: new FormControl('', [Validators.required, Validators.pattern('^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{6,}$')]),
      ConfirmPassword: new FormControl('', [Validators.required])
    }, {
      validators: this.comparePasswords
    })
  })

  comparePasswords(fg: FormGroup) {
    let confirmedPassword = fg.get('ConfirmPassword')

    if (confirmedPassword.errors === null || 'passwordMismatch' in confirmedPassword.errors) {
      if (fg.get('Password').value != confirmedPassword.value) {
        confirmedPassword.setErrors({ passwordMismatch: true })
      } else {
        confirmedPassword.setErrors(null)
      }
    }
  }

  registeredUsers = []
  allProducts = []
  productCategories = []

  getAllRegisteredUsers(): any {
    return this.http.get(this.ApiURL + '/Admin/Users')
  }

  getAllProducts(): any {
    return this.http.get(this.ApiURL + '/Admin/Products')
  }

  getAllProductCategories(): any {
    return this.http.get(this.ApiURL + '/Admin/ProductCategories')
  }

  createNewProduct() {
    let newProduct = {
      Name: this.createModelProduct.value.Name,
      Description: this.createModelProduct.value.Description,
      Price: this.createModelProduct.value.Price,
      Quantity: this.createModelProduct.value.Quantity,
      Category: this.createModelProduct.value.Category
    }

    return this.http.post(this.ApiURL + '/Admin/CreateProduct', newProduct)
  }

  addNewUser() {
    let newUser = {
      Username: this.createModelUser.value.Username,
      Password: this.createModelUser.value.Passwords.Password,
      EmailAddress: this.createModelUser.value.EmailAddress,
      Address: this.createModelUser.value.Address,
      PhoneNumber: this.createModelUser.value.PhoneNumber,
      BankAccountNumber: this.createModelUser.value.BankAccountNumber
    }

    return this.http.post(this.ApiURL + '/Admin/AddNewUser', newUser)
  }

  addNewAdmin() {
    let newAdmin = {
      Username: this.createModelAdmin.value.Username,
      Password: this.createModelAdmin.value.Password
    }

    return this.http.post(this.ApiURL + '/Admin/AddNewAdmin', newAdmin)
  }

  editProduct(productID) {
    return this.http.put(this.ApiURL + '/Admin/EditProduct/' + productID, productID)
  }

  removeProduct(productName: string) {
    return this.http.delete(this.ApiURL + '/Admin/RemoveProduct/' + productName)
  }

  removeUser(username: string) {
    return this.http.delete(this.ApiURL + '/Admin/RemoveUser/' + username)
  }
}
