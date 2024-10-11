import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContactCreateComponent } from './components/contacts/contact-create/contact-create.component';
import { ContactDetailsComponent } from './components/contacts/contact-details/contact-details.component';
import { ContactsListComponent } from './components/contacts/contacts-list/contacts-list.component';

const routes: Routes = [
  { path: 'contacts', component: ContactsListComponent },
  { path: 'contacts/create', component: ContactCreateComponent },
  { path: 'contacts/details/:id', component: ContactDetailsComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {


}
