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
import { CreateProductComponent } from './shop/admin/create-product/create-product.component';
import { AddUserComponent } from './shop/admin/add-user/add-user.component';
import { AddAdminComponent } from './shop/admin/add-admin/add-admin.component';
import { ShowRemoveUserComponent } from './shop/admin/show-remove-user/show-remove-user.component';
import { ShowRemoveProductComponent } from './shop/admin/show-remove-product/show-remove-product.component';
import { EditProductComponent } from './shop/admin/edit-product/edit-product.component';

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
    CreateProductComponent,
    AddUserComponent,
    AddAdminComponent,
    ShowRemoveUserComponent,
    ShowRemoveProductComponent,
    EditProductComponent
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
