import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './auth/auth.guard';
import { AddAdminComponent } from './shop/admin/add-admin/add-admin.component';
import { AddUserComponent } from './shop/admin/add-user/add-user.component';
import { AdminComponent } from './shop/admin/admin.component';
import { CreateProductComponent } from './shop/admin/create-product/create-product.component';
import { EditProductComponent } from './shop/admin/edit-product/edit-product.component';
import { LoginAdminComponent } from './shop/admin/login-admin/login-admin.component';
import { ShowRemoveAdminComponent } from './shop/admin/show-remove-admin/show-remove-admin.component';
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
  { path: 'admin/login', component: LoginAdminComponent },
  { path: 'admin/home', component: AdminComponent },
  { path: 'admin/users', component: ShowRemoveUserComponent },
  { path: 'admin/admins', component: ShowRemoveAdminComponent },
  { path: 'admin/add-user', component: AddUserComponent },
  { path: 'admin/add-admin', component: AddAdminComponent },
  { path: 'admin/products', component: ShowRemoveProductComponent },
  { path: 'admin/create-product', component: CreateProductComponent },
  { path: 'admin/edit/:id', component: EditProductComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
