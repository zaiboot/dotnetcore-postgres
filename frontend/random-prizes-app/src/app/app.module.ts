import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CustomerInfoComponent } from './customer-info/customer-info.component';
import { PrizeInfoComponent } from './prize-info/prize-info.component';

@NgModule({
  declarations: [
    AppComponent,
    CustomerInfoComponent,
    PrizeInfoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
