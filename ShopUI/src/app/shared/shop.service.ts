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

  getCategories(): any {
    return this.http.get(this.ApiURL + '/Shop/ProductCategories')
  }

  getProducts(): any {
    return this.http.get(this.ApiURL + '/Shop/Products')
  }

  getProductsByCategories(category): any {
    return this.http.get(this.ApiURL + '/Shop/Products/' + category)
  }
}
