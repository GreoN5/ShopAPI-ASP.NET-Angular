import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './auth/auth.guard';
import { AdminComponent } from './shop/admin/admin.component';
import { CreateProductComponent } from './shop/admin/create-product/create-product.component';
import { EditProductComponent } from './shop/admin/edit-product/edit-product.component';
import { ShowRemoveProductComponent } from './shop/admin/show-remove-product/show-remove-product.component';
import { ShowRemoveUserComponent } from './shop/admin/show-remove-user/show-remove-user.component';
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
  { path: 'admin/users', component: ShowRemoveUserComponent, canActivate: [AuthGuard] },
  { path: 'admin/products', component: ShowRemoveProductComponent, canActivate: [AuthGuard] },
  { path: 'admin/create-product', component: CreateProductComponent, canActivate: [AuthGuard] },
  { path: 'admin/edit/:id', component: EditProductComponent, canActivate: [AuthGuard] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
