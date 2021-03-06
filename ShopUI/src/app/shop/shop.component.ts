import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { ShopService } from '../shared/shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent implements OnInit {

  constructor(public shopService: ShopService, private route: ActivatedRoute) { }

  userRole = localStorage.getItem('role')

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
}
