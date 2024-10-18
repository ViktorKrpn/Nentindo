import { HTTP_INTERCEPTORS, provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component.js';
import { ContactDetailsComponent } from './components/contacts/contact-details/contact-details.component';
import { ContactCreateComponent } from './components/contacts/contact-create/contact-create.component';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { RouterLink, RouterOutlet } from '@angular/router';
import { ContactsListComponent } from './components/contacts/contacts-list/contacts-list.component';
import { ContactCreateCsvFileComponent } from './components/contacts/contact-create-csv-file/contact-create-csv-file.component';
import { LoginComponent } from './components/login/login/login.component';
import { LayoutComponent } from './components/layout/layout.component';
import { TokenInterceptor } from './core/token-interceptor';
@NgModule({
  declarations: [
    AppComponent,
    ContactDetailsComponent,
    ContactCreateComponent,
    ContactsListComponent,
    ContactCreateCsvFileComponent,
    LoginComponent,
    LayoutComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    RouterLink,
    RouterOutlet,
    BrowserAnimationsModule, // required animations module
    ToastrModule.forRoot(), // ToastrModule added
  ],
  providers: [provideHttpClient(withInterceptorsFromDi()),
  { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true },],
  bootstrap: [AppComponent]
})
export class AppModule { }
