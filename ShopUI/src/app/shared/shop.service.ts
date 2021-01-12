import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  readonly ApiURL = 'https://localhost:44369' //URL to the server

  constructor(private http: HttpClient) { }

  products = []
  productCategories = []
  productsByCategories = []
  productsInCart = []

  getCategories(): any {
    return this.http.get(this.ApiURL + '/Shop/ProductCategories')
  }

  getProducts(): any {
    return this.http.get(this.ApiURL + '/Shop/Products')
  }

  getProductsByCategories(category): any {
    return this.http.get(this.ApiURL + '/Shop/Products/' + category)
  }

  showCart(): any {
    return this.http.get(this.ApiURL + '/Shop/' + this.getLoggedUser() + '/Cart')
  }

  cartPrice() {
    return this.http.get(this.ApiURL + '/Shop/' + this.getLoggedUser() + '/Cart/FinalPrice')
  }

  addProductToCart(productName) {
    return this.http.post(this.ApiURL + '/Shop/' + this.getLoggedUser() + '/Cart/AddProduct/' + productName, productName)
  }

  changeQuantityOfProduct(productName) {
    return this.http.put(this.ApiURL + '/Shop/' + this.getLoggedUser() + '/Cart/' + productName + '/ChangeQuantity', productName)
  }

  removeProductFromCart(productName) {
    return this.http.delete(this.ApiURL + '/Shop/' + this.getLoggedUser() + '/Cart/RemoveProduct/' + productName)
  }

  removeAllProductFromCart() {
    return this.http.delete(this.ApiURL + '/Shop/' + this.getLoggedUser() + '/Cart')
  }

  getLoggedUser() {
    return localStorage.getItem('loggedUser')
  }
}
