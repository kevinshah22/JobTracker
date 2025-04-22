import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { UserLoginModel } from '../../Models/login-request.model'
import { CommonModule } from '@angular/common';
import { Subject } from 'rxjs';
import { EncryptDecryptService } from '../../core/encryption.decryption';

@Component({
  selector: 'app-login',
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
  standalone: true
})
export class LoginComponent implements OnInit, OnDestroy {
  loginForm: FormGroup;
  errorMsg: string = '';
  private destroy$ = new Subject<void>();

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router,
    private encryptDecryptService: EncryptDecryptService
  ) {
    this.loginForm = this.fb.group({
      email: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      email: ['', Validators.required],
      password: ['', Validators.required]
    });

    this.loginForm.reset();
  }

  onSubmit(): void {
    const data: UserLoginModel = this.loginForm.value;
    const userPassword: string = this.loginForm.value.password;

    data.password = this.encryptDecryptService.encryptUsingAES256(userPassword);

    this.authService.login(data).subscribe({
      next: () => {
        this.errorMsg = '';
        this.loginForm.reset();
        this.router.navigate(['/jobs']);
      },
      error: (err) => {
        console.log(err);
        this.loginForm.reset();
        this.errorMsg = err.error.responseException.exceptionMessage;
      }
    });
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }
}
