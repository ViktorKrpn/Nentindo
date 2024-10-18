import { HttpClient, HttpResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IContact } from "../../types/contacts";
import { IGenericResponse } from "../../types/IGenericResponse"
import { map } from 'rxjs/operators';
import { config } from "../../../environments/environment";
@Injectable({
  providedIn: 'root',
})

export class ContactsService {

  contactsApiUrl = `${config.apiHost}/api/contacts`;

  constructor(private http: HttpClient) {
  }

  getContacts(): Observable<IGenericResponse<IContact[]>> {
    console.log(config)
    console.log(this.contactsApiUrl)
    return this.http
      .get<IGenericResponse<IContact[]>>(this.contactsApiUrl)
  }

  createContact(contact: IContact): Observable<IGenericResponse<IContact>> {
    return this.http
      .post<any>(`${this.contactsApiUrl}/create`, contact)
  }

  getContactById(id: number): Observable<IGenericResponse<IContact>> {
    return this.http
      .get<IGenericResponse<IContact>>(`${this.contactsApiUrl}/${id}`)
  }

  checkIfContactsExists(emails: string[]): Observable<IGenericResponse<Record<string, boolean>>> {
    return this.http
      .post<IGenericResponse<Record<string, boolean>>>(`${this.contactsApiUrl}/CheckIfEmailsExist`, emails)
  }
  createBatchContacts(contacts: IContact[]): Observable<IGenericResponse<string>> {
    return this.http
      .post<IGenericResponse<string>>(`${this.contactsApiUrl}/create/batch`, contacts)
  }

}
