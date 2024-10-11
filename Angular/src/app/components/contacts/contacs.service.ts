import { HttpClient, HttpResponse } from "@angular/common/http";
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
      .get<IGenericResponse<IContact[]>>('https://localhost:7229/api/contacts')
  }

  createContact(contact: IContact): Observable<IGenericResponse<IContact>> {
    return this.http
      .post<any>('https://localhost:7229/api/contacts/create', contact)
  }

  getContactById(id: number): Observable<IGenericResponse<IContact>> {
    return this.http
      .get<IGenericResponse<IContact>>(`https://localhost:7229/api/contacts/${id}`)

  }

}
