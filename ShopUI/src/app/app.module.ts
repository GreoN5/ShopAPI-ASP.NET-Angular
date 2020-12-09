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

@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    RegistrationComponent,
    LoginComponent,
    ShopComponent,
    CartComponent,
    HeaderComponent,
    ProductsByCategoriesComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
