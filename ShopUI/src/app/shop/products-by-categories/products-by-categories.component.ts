import { Component, OnInit } from '@angular/core';
import { ShopService } from 'src/app/shared/shop.service';

@Component({
  selector: 'app-products-by-categories',
  templateUrl: './products-by-categories.component.html',
  styleUrls: ['./products-by-categories.component.css']
})
export class ProductsByCategoriesComponent implements OnInit {

  constructor(public shopService: ShopService) { }

  ngOnInit(): void {
  }
}
