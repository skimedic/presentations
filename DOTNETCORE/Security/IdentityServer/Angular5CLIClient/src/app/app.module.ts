import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AuthHttpService } from './auth-http.service';
import { AuthService } from './auth.service';
import { AuthInterceptor } from './auth-interceptor';
import { AppComponent } from './app.component';


@NgModule({
  declarations: [
      AppComponent,
  ],
  imports: [
      CommonModule,
      BrowserModule,
      HttpModule,
      HttpClientModule,
      FormsModule
  ],
  providers: [
      { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
      AuthHttpService,
      AuthService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
