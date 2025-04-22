import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { RegistrationModel } from '../../Models/register-request.model';
import { RegistrationService } from '../../services/registration.service';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-registration',
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './registration.component.html',
  styleUrl: './registration.component.scss',
  standalone: true
})
export class RegistrationComponent {
  registrationForm: FormGroup;
  errorMsg: string = '';

  constructor(
    private fb: FormBuilder,
    private registrationService: RegistrationService,
    private router: Router
  ) {
    this.registrationForm = this.fb.group({
      fName: ['', Validators.required],
      lName: ['', Validators.required],
      email: ['', Validators.required, Validators.email],
      password: ['', Validators.required]
    });

  }

  onSubmit(): void {
    const data: RegistrationModel = this.registrationForm.value;

    this.registrationService.register(data).subscribe({
      next: () => {
        this.errorMsg = '';
        this.router.navigate(['/login']); 
      },
      error: (err) => {
        console.log(err);
        this.errorMsg = err.error.responseException.exceptionMessage;
      }
    });
  }
}
