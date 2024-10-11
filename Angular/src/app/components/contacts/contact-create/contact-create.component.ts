import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Route, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ContactsService } from '../contacs.service';

@Component({
  selector: 'app-contact-create',
  templateUrl: './contact-create.component.html',
  styleUrl: './contact-create.component.css'
})
export class ContactCreateComponent {

  createContactForm: FormGroup;

  constructor(private fb: FormBuilder, private contactsService: ContactsService, private toastr: ToastrService, private router: Router) { }

  ngOnInit(): void {
    this.createContactForm = this.fb.group({
      salutation: [''],  // You can add Validators if needed
      firstName: ['', [Validators.required]],
      lastName: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      supplierId: [null],  // For optional values, initialize with null
      subcontractorId: [null]
    });
  }





  onSubmit() {
    if (this.createContactForm.valid) {
      this.contactsService.createContact(this.createContactForm.value).subscribe((response) => {

        const { isSuccessful, errors, result: contact } = response;

        if (isSuccessful) {
          console.log('Helllo')
          this.toastr.success('Contact created successfully')
          this.router.navigate(['/contacts/details', contact.id])
          return
        }
        if (errors.length > 0) {
          this.toastr.error(errors.map(error => error).join('\n'))
        }

      })
    } else {
      this.toastr.error('Something is wrong with the form. Please check the form and try again.');
    }
  }

}
