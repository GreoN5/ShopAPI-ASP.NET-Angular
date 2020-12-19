import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './auth/auth.guard';
import { ProductsByCategoriesComponent } from './shop/products-by-categories/products-by-categories.component';
import { ShopComponent } from './shop/shop.component';
import { CartComponent } from './user/cart/cart.component';
import { LoginComponent } from './user/login/login.component';
import { RegistrationComponent } from './user/registration/registration.component';

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: ShopComponent },
  { path: 'home/:category', component: ProductsByCategoriesComponent },
  { path: 'user/registration', component: RegistrationComponent },
  { path: 'user/login', component: LoginComponent },
  { path: 'user/cart', component: CartComponent, canActivate: [AuthGuard] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
