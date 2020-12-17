import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ShopService } from 'src/app/shared/shop.service';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor(public shopService: ShopService, public userService: UserService, private router: Router) { }

  ngOnInit(): void {
    this.showCategories()
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

  navigateToCategory(category) {
    this.router.navigateByUrl('/home/' + category)
  }

  navigateToRegistrationForm() {
    this.router.navigateByUrl('/user/registration')
  }

  navigateToLoginForm() {
    this.router.navigateByUrl('/user/login')
  }

  navigateToCart() {
    this.router.navigateByUrl('/user/cart')
  }

  getLoggedUser() {
    return localStorage.getItem('loggedUser')
  }

  isLoggedUser() {
    let user = this.getLoggedUser()

    if (user === null) {
      return false
    }

    return true
  }
}
