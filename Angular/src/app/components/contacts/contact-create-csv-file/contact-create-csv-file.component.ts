import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { IContact } from '../../../types/contacts';
import { ContactsService } from '../contacs.service';


type IContactDoesExist = IContact & { doesExist: boolean }

@Component({
  selector: 'app-contact-create-csv-file',
  templateUrl: './contact-create-csv-file.component.html',
  styleUrl: './contact-create-csv-file.component.css'
})

export class ContactCreateCsvFileComponent {

  form: FormGroup;
  contacts: IContactDoesExist[] = []

  constructor(private contactsService: ContactsService, private toastr: ToastrService, private router: Router, private fb: FormBuilder) {
    this.form = this.fb.group({
      csvFile: [null, Validators.required]  // Or the necessary validators
    });
  }

  onUploadedCsvFile(event: any) {
    console.log(event.target);
    const input = event.target as HTMLInputElement;
    const files = input.files as FileList;
    console.log(files);
    if (files && files.length > 0) {
      const file: File = files.item(0) as File;
      let reader: FileReader = new FileReader();
      reader.readAsText(file);
      reader.onload = (e) => {
        let csv: string = reader.result as string;
        const result = this.CsvToArray(csv, ',');
        this.setContacts(result.slice(1, -2) as string[][])
      }
    }
  }

  setContacts(contacts: string[][]) {
    const mappedContacts = contacts.map(([salutation, firstName, lastName, email]) => {
      console.log(salutation, firstName, lastName, email);
      return {
        salutation: salutation.replace(/\s+/g, ''),
        firstName: firstName.replace(/\s+/g, ''),
        lastName: lastName.replace(/\s+/g, ''),
        email: email.replace(/\s+/g, '')
      }
    })

    const allEmails = mappedContacts.map(contact => contact.email)

    this.contactsService.checkIfContactsExists(allEmails).subscribe((response) => {
      this.contacts = mappedContacts.map((contact, index) => {
        return {
          ...contact,
          doesExist: response.result[contact.email]
        }
      })
      console.log(this.contacts)

    })
  }

  onSubmitForm() {
    console.log("on submit form")
    this.contactsService.createBatchContacts(this.contacts).subscribe((response) => {
      const { isSuccessful, result } = response;
      if (isSuccessful) {
        this.toastr.success(result)
        this.router.navigate(['/contacts'])
        return
      }

    })
  }

  CsvToArray(strData: string, strDelimiter: string): string[][] {
    // Check to see if the delimiter is defined. If not,
    // then default to comma.
    strDelimiter = (strDelimiter || ",");

    // Create a regular expression to parse the CSV values.
    var objPattern = new RegExp(
      (
        // Delimiters.
        "(\\" + strDelimiter + "|\\r?\\n|\\r|^)" +

        // Quoted fields.
        "(?:\"([^\"]*(?:\"\"[^\"]*)*)\"|" +

        // Standard fields.
        "([^\"\\" + strDelimiter + "\\r\\n]*))"
      ),
      "gi"
    );


    // Create an array to hold our data. Give the array
    // a default empty first row.
    var arrData = [[]];

    // Create an array to hold our individual pattern
    // matching groups.
    var arrMatches = null;


    // Keep looping over the regular expression matches
    // until we can no longer find a match.
    while (arrMatches = objPattern.exec(strData)) {

      // Get the delimiter that was found.
      var strMatchedDelimiter = arrMatches[1];

      // Check to see if the given delimiter has a length
      // (is not the start of string) and if it matches
      // field delimiter. If id does not, then we know
      // that this delimiter is a row delimiter.
      if (
        strMatchedDelimiter.length &&
        (strMatchedDelimiter != strDelimiter)
      ) {

        // Since we have reached a new row of data,
        // add an empty row to our data array.
        arrData.push([]);

      }


      // Now that we have our delimiter out of the way,
      // let's check to see which kind of value we
      // captured (quoted or unquoted).
      if (arrMatches[2]) {

        // We found a quoted value. When we capture
        // this value, unescape any double quotes.
        var strMatchedValue = arrMatches[2].replace(
          new RegExp("\"\"", "g"),
          "\""
        );

      } else {

        // We found a non-quoted value.
        var strMatchedValue = arrMatches[3];

      }


      // Now that we have our value string, let's add
      // it to the data array.
      arrData[arrData.length - 1].push(strMatchedValue as never);
    }

    // Return the parsed data.
    return arrData;
  }

  identify(index: number, contact: IContact) {
    return contact.email
  }

}
