import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-contacts',
  templateUrl: './contacts.component.html',
  styleUrl: './contacts.component.css'
})
export class ContactsComponent {

  contacts: any[] = [];
  constructor(private http: HttpClient) {

  }

  ngOnInit() {
    this.http.get('https://localhost:7229/api/Contacts/getContacts').subscribe((response: any) => {
      console.log('response', response);
    });
  }
}
