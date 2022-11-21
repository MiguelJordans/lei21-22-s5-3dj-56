import {AddTruckFormComponent} from './components/add-truck-form/add-truck-form.component';
import {AddTruckServiceService} from './services/add-truck-service.service';
import {AppComponent} from './app.component';
import {AppRoutingModule} from './app-routing.module';
import {BrowserModule} from '@angular/platform-browser';
import {ErrorPageComponent} from './components/error-page/error-page.component';
import {HeaderComponent} from './components/header/header.component';
import {LoginPageComponent} from './components/login-page/login-page.component';
import {NgModule} from '@angular/core';
import {MatToolbarModule} from "@angular/material/toolbar";
import {MatIconModule} from "@angular/material/icon";
import {MatButtonModule} from "@angular/material/button";
import {MatListModule} from "@angular/material/list";
import {MatInputModule} from "@angular/material/input";
import {FormsModule} from "@angular/forms";
import {FleetManagerModule} from "./fleet-manager/fleet-manager.module";
import {BrowserAnimationsModule, NoopAnimationsModule} from "@angular/platform-browser/animations";
import { AddPackagingComponent } from './log-manager/components/add-packaging/add-packaging.component';
import { AddPackagingService } from 'src/app/services/add-packaging.service';

import { HttpClientModule, HttpClient } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    AddTruckFormComponent,
    LoginPageComponent,
    HeaderComponent,
    ErrorPageComponent,
    AddPackagingComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatListModule,
    MatInputModule,
    FormsModule,
    BrowserAnimationsModule,
    NoopAnimationsModule
  ],
  providers: [HttpClientModule,AddTruckServiceService,AddPackagingService],
  exports: [
    HeaderComponent,
    AddTruckFormComponent,
    LoginPageComponent,
    ErrorPageComponent,
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
