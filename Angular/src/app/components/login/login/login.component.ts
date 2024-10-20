import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { map } from 'rxjs';
import { ILoginRequest } from '../../../types/login';
import { LoginService } from '../login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  loginForm: FormGroup;

  constructor(private fb: FormBuilder,
    private router: Router,
    private loginService: LoginService) {
  }

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required]],
      password: ['', [Validators.required]],
    });
  }

  login() {
    console.log("login")
    const loginRequest: ILoginRequest = {
      Email: this.loginForm.controls['email'].value,
      Password: this.loginForm.controls['password'].value,
    }
    this.loginService
      .login(loginRequest)
      .subscribe({
        next: () => {
          this.router.navigate(['']).then(() => {
            // workaround: I need to reload the page because the links in layout component are not working
            location.reload();
          })
        },
        error: (error) => {
          console.log(error)
        },

      })
  }
}
