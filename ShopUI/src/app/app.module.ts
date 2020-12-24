import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserComponent } from './user/user.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { LoginComponent } from './user/login/login.component';
import { ShopComponent } from './shop/shop.component';
import { CartComponent } from './user/cart/cart.component';
import { HttpClientModule } from '@angular/common/http';
import { HeaderComponent } from './shop/header/header.component';
import { ProductsByCategoriesComponent } from './shop/products-by-categories/products-by-categories.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AdminComponent } from './shop/admin/admin.component';
import { ShowUsersComponent } from './shop/admin/show-users/show-users.component';
import { ShowProductsComponent } from './shop/admin/show-products/show-products.component';
import { CreateProductComponent } from './shop/admin/create-product/create-product.component';
import { AddUserComponent } from './shop/admin/add-user/add-user.component';
import { AddAdminComponent } from './shop/admin/add-admin/add-admin.component';
import { ShowChangeRemoveProductComponent } from './shop/admin/show-change-remove-product/show-change-remove-product.component';
import { ShowRemoveUserComponent } from './shop/admin/show-remove-user/show-remove-user.component';
import { ShowChangeRemoveProductsComponent } from './shop/admin/show-change-remove-products/show-change-remove-products.component';

@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    RegistrationComponent,
    LoginComponent,
    ShopComponent,
    CartComponent,
    HeaderComponent,
    ProductsByCategoriesComponent,
    AdminComponent,
    ShowUsersComponent,
    ShowProductsComponent,
    CreateProductComponent,
    AddUserComponent,
    AddAdminComponent,
    ShowChangeRemoveProductComponent,
    ShowRemoveUserComponent,
    ShowChangeRemoveProductsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
