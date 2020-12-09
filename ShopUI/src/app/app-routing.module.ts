import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProductsByCategoriesComponent } from './shop/products-by-categories/products-by-categories.component';
import { ShopComponent } from './shop/shop.component';
import { CartComponent } from './user/cart/cart.component';
import { LoginComponent } from './user/login/login.component';
import { RegistrationComponent } from './user/registration/registration.component';

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: ShopComponent },
  { path: 'home/:category', component: ProductsByCategoriesComponent },
  { path: 'home/registration', component: RegistrationComponent },
  { path: 'home/login', component: LoginComponent },
  { path: 'home/cart', component: CartComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
