import { Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { JobsComponent } from './components/JobApplication/jobs/jobs.component'

export const routes: Routes = [
    { path: '', component: LoginComponent },
    { path: 'jobs', component: JobsComponent }
];