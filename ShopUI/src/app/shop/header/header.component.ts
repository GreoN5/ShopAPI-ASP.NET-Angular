import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ShopService } from 'src/app/shared/shop.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor(public shopService: ShopService, private router: Router) { }

  ngOnInit(): void {
  }

  showProductsByCategory(category) {
    this.shopService.getProductByCategories(category).subscribe(
      data => {
        this.shopService.productByCategories = data
        this.router.navigateByUrl('/home/' + category)
      }, error => {
        console.log(error)
      }
    )
  }

  getLoggedUser() {
    return localStorage.getItem('loggedUser')
  }

  isLoggedUser = this.getLoggedUser() ? 'Cart' : 'Login'
}
