import {Component, EventEmitter, Input, Output} from '@angular/core';
import {MatSnackBar} from "@angular/material/snack-bar";
import {FormControl, Validators} from "@angular/forms";
import {PostService} from "../../../services/post.service";
import {Post} from "../../../_models/post";

@Component({
  selector: 'app-add-post',
  templateUrl: './add-post.component.html',
  styleUrls: ['./add-post.component.scss']
})
export class AddPostComponent {
  snackBar: MatSnackBar;
  post: Post = new Post();
  contentForm: FormControl;
  @Output() addClicked = new EventEmitter();
  @Input() subjectId!: string


  constructor(private postService: PostService, snackBar: MatSnackBar) {
    this.contentForm = new FormControl('', [Validators.required, Validators.minLength(10)]);
    this.snackBar = snackBar;
  }

  addPost() {
    this.post.subjectCode = this.subjectId;
    this.postService.addPost(this.post).subscribe(
      success => {
        this.snackBar.open('Post added', 'Close', {duration: 5000});
        this.post = new Post();
        this.onAddClicked();
      },
      error => {
        this.snackBar.open('Post create failed', 'Close', {duration: 5000});
      }
    );
  }

  public getCreateErrorMessage(): string {
    if (this.contentForm.hasError('required')) {
      return 'Post cannot be empty!'
    }
    return 'Post must be at least 10 characters long!';
  }

  onAddClicked() {
    this.addClicked.emit();
  }
}
