import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IContact } from '../../../types/contacts';
import { ContactsService } from '../contacs.service';

@Component({
  selector: 'app-contact-details',
  templateUrl: './contact-details.component.html',
  styleUrl: './contact-details.component.css'
})
export class ContactDetailsComponent {

  contact: IContact | null

  constructor(private contactsService: ContactsService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      const contactId: number = params['id'];
      this.contactsService.getContactById(contactId).subscribe((response) => {
        this.contact = response.result
      })

    });


  }

}
