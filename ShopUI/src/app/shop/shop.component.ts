import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ShopService } from '../shared/shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent implements OnInit {

  constructor(public shopService: ShopService, private router: Router) { }

  ngOnInit(): void {
    this.showCategories()
    this.showProducts()
  }

  showProducts() {
    this.shopService.getProducts().subscribe(
      data => {
        this.shopService.products = data
      }, error => {
        console.log(error)
      }
    )
  }

  showCategories() {
    this.shopService.getCategories().subscribe(
      data => {
        this.shopService.productCategories = data
      }, error => {
        console.log(error)
      }
    )
  }

  showProductsByCategories(category) {
    this.shopService.getProductByCategories(category).subscribe(
      data => {
        this.shopService.productByCategories = data
        this.router.navigateByUrl('/home/' + category)
      }, error => {
        console.log(error)
      }
    )
  }
}
