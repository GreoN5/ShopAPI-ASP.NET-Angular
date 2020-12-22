import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './auth/auth.guard';
import { AdminComponent } from './shop/admin/admin.component';
import { CreateProductComponent } from './shop/admin/create-product/create-product.component';
import { ShowProductsComponent } from './shop/admin/show-products/show-products.component';
import { ShowUsersComponent } from './shop/admin/show-users/show-users.component';
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
  { path: 'user/cart', component: CartComponent, canActivate: [AuthGuard] },
  { path: 'admin', component: AdminComponent, canActivate: [AuthGuard] },
  { path: 'admin/users', component: ShowUsersComponent, canActivate: [AuthGuard] },
  { path: 'admin/products', component: ShowProductsComponent, canActivate: [AuthGuard] },
  { path: 'admin/create-product', component: CreateProductComponent, canActivate: [AuthGuard] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
