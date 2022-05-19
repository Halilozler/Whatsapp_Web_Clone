import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { GirisComponent } from './giris/giris.component';
import { AnaSayfaComponent } from './ana-sayfa/ana-sayfa.component';
import { SolMenuComponent } from './sol-menu/sol-menu.component';
import { SagMenuComponent } from './sag-menu/sag-menu.component';
import { HttpClientModule } from "@angular/common/http";
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    GirisComponent,
    AnaSayfaComponent,
    SolMenuComponent,
    SagMenuComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
