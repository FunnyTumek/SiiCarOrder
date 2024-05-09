import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ModulesNavigationModule } from './shell/modules-navigation/modules-navigation.module';
import { LogoComponent } from './shell/logo/logo.component';
import { QuickActionsPanelComponent } from './shell/quick-actions-panel/quick-actions-panel.component';
import { OrdersModule } from './modules/orders/orders.module';
import { HttpClientModule } from '@angular/common/http';
import { MatButtonModule } from '@angular/material/button';
import {MatSnackBarModule} from '@angular/material/snack-bar';

@NgModule({
  declarations: [
    AppComponent,
    LogoComponent,
    QuickActionsPanelComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ModulesNavigationModule,
    OrdersModule,
    HttpClientModule,
    MatButtonModule,
    MatSnackBarModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
