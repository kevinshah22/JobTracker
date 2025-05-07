import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Router, NavigationStart, NavigationEnd, NavigationCancel, NavigationError } from '@angular/router';
import { LoadingService } from './core/loading.service';
import { SpinnerComponent } from './components/common/spinner/spinner.component';

@Component({
    selector: 'app-root',
    imports: [RouterOutlet, SpinnerComponent],
    templateUrl: './app.component.html',
    styleUrl: './app.component.scss',
    standalone: true
})
export class AppComponent {
  title = 'JobTracker App';

  // public Editor = ClassicEditor;
  //   public config = {
  //       licenseKey: '<YOUR_LICENSE_KEY>', // Or 'GPL'.
  //       plugins: [ Essentials, Paragraph, Bold, Italic, FormatPainter ],
  //       toolbar: [ 'undo', 'redo', '|', 'bold', 'italic', '|', 'formatPainter' ]
  //   }

  constructor(private router: Router, private loadingService: LoadingService) {
    this.router.events.subscribe(event => {
      if (event instanceof NavigationStart) {
        this.loadingService.show();
      } else if (
        event instanceof NavigationEnd ||
        event instanceof NavigationCancel ||
        event instanceof NavigationError
      ) {
        this.loadingService.hide();
      }
    });
  }
}
