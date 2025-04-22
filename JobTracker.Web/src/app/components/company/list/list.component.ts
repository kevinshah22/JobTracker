import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validator, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { CompanyModel } from '../../../Models/company.model';
import { CompanyService } from '../../../services/company.service';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-list',
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './list.component.html',
  styleUrl: './list.component.scss'
})
export class ListComponent implements OnInit, OnDestroy {
  companies: CompanyModel[] = [];
  errorMessage: string = '';

  private destroy$ = new Subject<void>();
  constructor(private companyService: CompanyService, private router: Router) { }

  ngOnInit(): void {
    this.companyService.list().subscribe({
      next: (response) => { this.companies = response; },
      error: (err) => { this.errorMessage = "Something went wrong!" }
    });
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

}
