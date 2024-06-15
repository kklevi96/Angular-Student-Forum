import {Component, EventEmitter, Input, Output} from '@angular/core';
import {Comment} from "../../../_models/comment";
import {MatSnackBar} from "@angular/material/snack-bar";
import {CommentService} from "../../../services/comment.service";
import {FormControl, Validators} from "@angular/forms";


@Component({
  selector: 'app-add-comment',
  templateUrl: './add-comment.component.html',
  styleUrls: ['./add-comment.component.scss']
})
export class AddCommentComponent {
  snackBar: MatSnackBar;
  comment: Comment = new Comment();
  contentForm: FormControl;
  @Output() addClicked = new EventEmitter();
  @Input() postId!: string


  constructor(private commentService: CommentService, snackBar: MatSnackBar) {
    this.contentForm = new FormControl('', [Validators.required, Validators.minLength(10)]);
    this.snackBar = snackBar;
  }

  addComment() {
    this.comment.postId = this.postId;
    this.commentService.addComment(this.comment).subscribe(
      success => {
        this.snackBar.open('Comment added', 'Close', {duration: 5000});
        this.comment = new Comment();
        this.onAddClicked();
      },
      error => {
        this.snackBar.open('Comment create failed', 'Close', {duration: 5000});
      }
    );
  }

  public getCreateErrorMessage(): string {
    if (this.contentForm.hasError('required')) {
      return 'Comment cannot be empty!'
    }
    return 'Comment must be at least 10 characters long!';
  }

  onAddClicked() {
    this.addClicked.emit();
  }
}
