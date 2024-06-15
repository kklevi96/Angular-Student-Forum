//https://stackblitz.com/edit/mat-grid-list-responsive?file=app%2Fapp.component.html,app%2Fdemo%2Fdemo.component.html

import {Component, OnInit} from '@angular/core';
import {Subject} from "../../../_models/subject";
import {SubjectService} from "../../../services/subject.service";
import {PostService} from "../../../services/post.service";
import {AuthService} from "../../../auth/auth.service";
import {MatSnackBar} from "@angular/material/snack-bar";

@Component({
  selector: 'app-list-subjects',
  templateUrl: './list-subjects.component.html',
  styleUrls: ['./list-subjects.component.scss']
})
export class ListSubjectsComponent implements OnInit {
  subjects!: Subject[];
  breakpoint: number = 5;
  snackBar: MatSnackBar
  showCreateForm: boolean = false;

  constructor(private subjectService: SubjectService, private postsService: PostService, public authService: AuthService, snackBar: MatSnackBar) {
    this.snackBar = snackBar;
  }

  ngOnInit(): void {
    this.getSubjects()
  }

  getSubjects() {
    this.subjectService.getSubjects().subscribe(response => {
      this.subjects = response;
      this.subjects.forEach(subject => {
        this.postsService.getPosts(subject.subjectCode).subscribe(postsResponse => {
          subject.posts = postsResponse;
        })
      })
    });
    console.log('Subjects got');
  }

  deleteSubject(subjectId: string) {
    if (confirm("Are you sure to delete the subject? Any posts and comments under this subject will also be deleted and will not be recoverable.")) {
      this.subjectService.deleteSubject(subjectId).subscribe(
        (success) => {
          this.snackBar.open('Delete was successful', 'Close', {duration: 5000});
          this.getSubjects();
        },
        (error) => {
          this.snackBar.open('Delete failed', 'Close', {duration: 5000});
        }
      );
    }
  }

  refresh() {
    this.showCreateForm = false;
    this.getSubjects();
  }
}
