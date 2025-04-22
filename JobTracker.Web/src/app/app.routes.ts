import { Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { RegistrationComponent } from './components/registration/registration.component'
import { JobsComponent } from './components/JobApplication/jobs/jobs.component'
import { LayoutComponent } from './components/layout/layout.component';
import { AuthGuard } from './core/auth.guard';
import { ListComponent } from './components/company/list/list.component';
import { CreatecompanyComponent } from './components/company/createcompany/createcompany.component';

export const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'registration', component: RegistrationComponent },
  {
    path: '',
    component: LayoutComponent,
    canActivate: [AuthGuard], // optional
    children: [
      { path: 'jobs', component: JobsComponent },
      { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
      { path: 'companies', component: ListComponent },
      { path: 'company/edit/:id', component: CreatecompanyComponent },
      { path: 'company/add', component: CreatecompanyComponent },
    ]
  },
  { path: '**', redirectTo: '' }
];