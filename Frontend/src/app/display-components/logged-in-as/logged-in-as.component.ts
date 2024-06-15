import {Component} from '@angular/core';
import {AuthService} from '../../auth/auth.service'

@Component({
  selector: 'app-logged-in-as',
  templateUrl: './logged-in-as.component.html',
  styleUrls: ['./logged-in-as.component.scss']
})
export class LoggedInAsComponent {
  protected readonly window = window;

  constructor(public authService: AuthService) {
  }

  showText(): boolean {
    return this.window.innerWidth > 500
  }

  onResize(event: Event) {
    this.showText();
  }
}
