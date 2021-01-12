import { Component, OnInit } from '@angular/core';
import { ShopService } from 'src/app/shared/shop.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.cart()
  }

  cart() {
    this.shopService.showCart().subscribe(
      data => {
        this.shopService.productsInCart = data
      }, error => {
        console.log(error)
      }
    )
  }
}
