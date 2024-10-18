import { HttpClient, HttpResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IContact } from "../../types/contacts";
import { IGenericResponse } from "../../types/IGenericResponse"
import { filter, map, tap } from 'rxjs/operators';
import { config } from "../../../environments/environment";
import { ILoginRequest } from "../../types/login";
import { TokenService } from "../../services/token.service";
import { Token } from "../../types/token";
import { Router } from "@angular/router";

@Injectable({
    providedIn: 'root',
})

export class LoginService {

    authApiUrl = `${config.apiHost}/api/authenticate`;

    constructor(private http: HttpClient, private tokenService: TokenService, private router: Router) {

    }

    login(loginRequest: ILoginRequest): Observable<Token> {
        return this.http
            .post<Token>(`${this.authApiUrl}/login`, loginRequest)
            .pipe(
                tap((response: Token) => {
                    this.tokenService.set(response);
                })
            )
    }

    check() {
        return this.tokenService.valid();
    }
}