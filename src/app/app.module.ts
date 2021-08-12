import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { SlickCarouselModule } from 'ngx-slick-carousel';
import { BuyInsuranceComponent } from './buy-insurance/buy-insurance.component';  
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { VechicleRegistrationService } from './vechicle-registration.service';
import {HttpClientModule} from '@angular/common/http';



@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    BuyInsuranceComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    SlickCarouselModule,

    FormsModule,
    HttpClientModule,
    

  ],
  providers: [VechicleRegistrationService],
  bootstrap: [AppComponent]
})
export class AppModule {


 }
