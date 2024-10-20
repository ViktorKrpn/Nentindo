import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { ArticlesListComponent } from './components/articles/articles-list/articles-list.component';
import { ArticleCreateComponent } from './components/articles/create-article/article-create.component';
import { ContactCreateCsvFileComponent } from './components/contacts/contact-create-csv-file/contact-create-csv-file.component';
import { ContactCreateComponent } from './components/contacts/contact-create/contact-create.component';
import { ContactDetailsComponent } from './components/contacts/contact-details/contact-details.component';
import { ContactsListComponent } from './components/contacts/contacts-list/contacts-list.component';
import { LayoutComponent } from './components/layout/layout.component';
import { LoginComponent } from './components/login/login/login.component';
import { AuthGuard } from './core/auth.guard';

const routes: Routes = [
  {
    path: '',
    component: LayoutComponent,
    canActivate: [AuthGuard],
    children: [
      { path: 'contacts', component: ContactsListComponent },
      { path: 'contacts/create', component: ContactCreateComponent },
      { path: 'contacts/createCsvFile', component: ContactCreateCsvFileComponent },
      { path: 'contacts/details/:id', component: ContactDetailsComponent },
      { path: 'articles/create', component: ArticleCreateComponent },
      { path: 'articles', component: ArticlesListComponent }
    ],
  },
  { path: 'login', component: LoginComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule {


}
