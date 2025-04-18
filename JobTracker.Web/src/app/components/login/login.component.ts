import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import {UserLoginModel} from '../../Models/login-request.model'

@Component({
    selector: 'app-login',
    imports: [ReactiveFormsModule],
    templateUrl: './login.component.html',
    styleUrl: './login.component.scss',
    standalone: true
})
export class LoginComponent {
  loginForm: FormGroup;
  errorMsg: string = '';

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) {
    this.loginForm = this.fb.group({
      email: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  onSubmit(): void {
    const data: UserLoginModel = this.loginForm.value;

    this.authService.login(data).subscribe({
      next: () => {
        this.errorMsg = '';
        this.router.navigate(['/jobs']); // route to user list or dashboard
      },
      error: (err) => {
        this.errorMsg = err.message;
      }
    });
  }
}
