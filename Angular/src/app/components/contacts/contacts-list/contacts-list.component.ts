import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { IContact } from '../../../types/contacts';
import { ContactsService } from '../contacs.service';

@Component({
  selector: 'app-contacts-list',
  templateUrl: './contacts-list.component.html',
  styleUrl: './contacts-list.component.css'
})
export class ContactsListComponent {

  contacts: IContact[] = [];

  constructor(private contactsService: ContactsService) {

  }

  ngOnInit() {
    this.contactsService.getContacts().subscribe((response) => {
      console.log(response)
      this.contacts = response.result
    })
  }
}
