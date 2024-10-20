import { HttpClient, HttpResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IContact } from "../../types/contacts";
import { IGenericResponse } from "../../types/IGenericResponse"
import { map } from 'rxjs/operators';
import { config } from "../../../environments/environment";
import { Article, CreateArticleRequestBody } from "../../types/articles";

@Injectable({
    providedIn: 'root',
})

export class ArticlesService {

    contactsApiUrl = `${config.apiHost}/api/articles`;

    constructor(private http: HttpClient) {
    }

    createArticle(createArticleRequest: CreateArticleRequestBody): Observable<IGenericResponse<Article>> {
        return this.http
            .post<IGenericResponse<Article>>(`${this.contactsApiUrl}/create`, createArticleRequest)
    }

    getArticles(): Observable<IGenericResponse<Article[]>> {
        return this.http
            .get<IGenericResponse<Article[]>>(`${this.contactsApiUrl}`)
    }



}
