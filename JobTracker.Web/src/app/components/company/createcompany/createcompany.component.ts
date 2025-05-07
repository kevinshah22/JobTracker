import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, ReactiveFormsModule, FormsModule } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { CommonModule } from '@angular/common';
import { CompanyService } from '../../../services/company.service';
import { CompanyModel } from '../../../Models/company.model';

@Component({
  selector: 'app-createcompany',
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './createcompany.component.html',
  styleUrl: './createcompany.component.scss',
  standalone: true
})
export class CreatecompanyComponent implements OnInit {
  companyId: number = 0;
  companyForm: FormGroup;
  errorMessage: string = '';
  //companyData: CompanyModel;

  constructor(private router: Router,
    private activatedRoute: ActivatedRoute,
    private fb: FormBuilder,
    private companyService: CompanyService
  ) {
    this.companyForm = this.fb.group({
      name: ['', Validators.required],
      description: ['']
    });
  }

  ngOnInit(): void {
    if (this.activatedRoute.snapshot.paramMap.has('id')) {
      this.companyId = Number(this.activatedRoute.snapshot.paramMap.get('id'));
      console.log(this.companyId);

      if (this.companyId > 0) {
        this.companyService.get(this.companyId).subscribe((company) => {
          this.companyForm.patchValue(company)
        });

      }
    }
    else {
      this.companyForm = this.fb.group({
        name: ['', Validators.required],
        description: ['']
      });

      this.companyForm.reset();
    }
  }

  onSubmit(): void {
    const companyData: CompanyModel = this.companyForm.value;

    if (this.companyId > 0) {
      companyData.id = this.companyId;
      this.companyService.update(companyData).subscribe({
        next: (response) => {
          this.companyForm.reset();
          this.router.navigate(['/companies']);
        },
        error: (err) => { this.errorMessage = "Something went wrong!" }
      });
    }
    else {
      this.companyService.save(companyData).subscribe({
        next: (response) => {
          this.companyForm.reset();
          this.router.navigate(['/companies']);
        },
        error: (err) => { this.errorMessage = "Something went wrong!" }
      });
    }
  }
}
