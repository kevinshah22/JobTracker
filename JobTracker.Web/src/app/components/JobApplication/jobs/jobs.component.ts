import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CdkDragDrop, DragDropModule, transferArrayItem } from '@angular/cdk/drag-drop';
import { JobApplicationModel } from '../../../Models/job-application.model';
import { jobApplicationService } from '../../../services/job.application.service';
import { Jobstatus } from '../../../Models/jobstatus';
import { Subject } from 'rxjs';
import { Router } from '@angular/router';

@Component({
    selector: 'app-jobs',
    imports: [CommonModule, DragDropModule],
    templateUrl: './jobs.component.html',
    styleUrl: './jobs.component.scss'
})
export class JobsComponent {
    jobs: JobApplicationModel[] = [];
    errorMessage: string = '';

    private destroy$ = new Subject<void>();
    constructor(private jobService: jobApplicationService, private router: Router) { }

    ngOnInit(): void {
        this.jobService.list().subscribe({
            next: (response) => { this.jobs = response; },
            error: (err) => { this.errorMessage = "Something went wrong!" }
        });
    }

    

}
