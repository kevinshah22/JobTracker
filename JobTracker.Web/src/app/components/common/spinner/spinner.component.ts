import { Component } from '@angular/core';
import { LoadingService } from '../../../core/loading.service';
import { AsyncPipe, CommonModule } from '@angular/common';

@Component({
  selector: 'app-spinner',
  imports: [AsyncPipe, CommonModule],
  templateUrl: './spinner.component.html',
  styleUrl: './spinner.component.scss',
  standalone: true
})
export class SpinnerComponent {
  isLoading$ = this.loadingService.isLoading$;
  constructor(private loadingService: LoadingService) { }
}
