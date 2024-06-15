import {Component, OnInit} from '@angular/core';
import {Subject} from "./_models/subject";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Frontend';

  public subjects!: Subject[]

  constructor() {
  }

  ngOnInit() {

  }
}
