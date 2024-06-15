import {Component, OnInit} from '@angular/core';
import {Router} from "@angular/router";
import {AuthService} from '../auth.service';


@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.scss']
})
export class LogoutComponent implements OnInit {
  router: Router

  constructor(router: Router, private authService: AuthService) {
    this.router = router
  }

  ngOnInit(): void {
    this.authService.doLogout();

    this.router.navigate(['/home'])
  }

}
