import { provideHttpClient } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component.js';
import { ContactDetailsComponent } from './components/contacts/contact-details/contact-details.component';
import { ContactsListComponent } from './components/contacts/contacts-list/contacts-list.component';

@NgModule({
  declarations: [
    AppComponent,

    ContactDetailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [provideHttpClient()],
  bootstrap: [AppComponent]
})
export class AppModule { }
