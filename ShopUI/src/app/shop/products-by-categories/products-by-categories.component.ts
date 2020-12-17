import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { ShopService } from 'src/app/shared/shop.service';

@Component({
  selector: 'app-products-by-categories',
  templateUrl: './products-by-categories.component.html',
  styleUrls: ['./products-by-categories.component.css']
})
export class ProductsByCategoriesComponent implements OnInit {

  constructor(public shopService: ShopService, private router: ActivatedRoute) { }

  categoryParameter;

  ngOnInit(): void {
    this.router.paramMap.subscribe(paramMap => {
      this.categoryParameter = paramMap.get('category')
      this.showProductsByCategory(this.categoryParameter)
    })
  }

  showProductsByCategory(category) {
    this.shopService.getProductsByCategories(category).subscribe(
      data => {
        this.shopService.productsByCategories = data
      }, error => {
        console.log(error)
      }
    )
  }
}
