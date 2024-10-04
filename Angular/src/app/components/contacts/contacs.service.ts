import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IContact } from "../../types/contacts";
import { IGenericResponse } from "../../types/IGenericResponse"
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})

export class ContactsService {

  constructor(private http: HttpClient) {
  }

  getContacts(): Observable<IGenericResponse<IContact[]>> {
    return this.http
      .get<IGenericResponse<IContact[]>>('https://localhost:7229/api/Contacts/getContacts')
      .pipe(map((response) => {
        console.log('this is response from getContacts: ', response)
        return response
      }));
  }

}
