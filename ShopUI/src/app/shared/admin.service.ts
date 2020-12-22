import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  readonly ApiURL = 'https://localhost:44369' //URL to the server

  constructor(private http: HttpClient) { }

  registeredUsers = []

  getAllRegisteredUsers() {
    return this.http.get(this.ApiURL + '/Admin/Users')
  }

  getAllProducts() {
    return this.http.get(this.ApiURL + '/Admin/Products')
  }

  createNewProduct(newProduct) {
    return this.http.post(this.ApiURL + '/Admin/CreateProduct', newProduct)
  }

  changeQuantityOfProduct(productName, newQuantity) {
    return this.http.put(this.ApiURL + '/Admin/ChangeQuantity/' + productName + newQuantity, productName, newQuantity)
  }

  removeProduct(productName) {
    return this.http.delete(this.ApiURL + '/Admin/RemoveProduct/' + productName)
  }
}
