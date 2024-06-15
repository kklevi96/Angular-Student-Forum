import {Component} from '@angular/core';
import {Comment} from "../../../_models/comment";
import {MatSnackBar} from "@angular/material/snack-bar";
import {ActivatedRoute, Router} from "@angular/router";
import {AuthService} from "../../../auth/auth.service";
import {CommentService} from "../../../services/comment.service";
import {FormControl, Validators} from "@angular/forms";

@Component({
  selector: 'app-edit-comment',
  templateUrl: './edit-comment.component.html',
  styleUrls: ['./edit-comment.component.scss']
})
export class EditCommentComponent {
  commentId: string = '';
  comment!: Comment;
  snackBar: MatSnackBar;
  contentForm: FormControl;
  oldContent: string = '';


  constructor(private commentService: CommentService, private route: ActivatedRoute, public authService: AuthService, snackBar: MatSnackBar, public router: Router) {
    this.snackBar = snackBar;
    this.contentForm = new FormControl('', [Validators.required, Validators.minLength(10)]);
  }


  ngOnInit(): void {
    const routeParams = this.route.snapshot.paramMap;
    this.commentId = String(routeParams.get('commentid'));
    this.getComment();
  }

  editComment() {
    this.commentService.editComment(this.commentId, this.comment).subscribe(
      (success) => {
        this.snackBar.open('Update was successful!', 'Close', {duration: 5000})
        this.router.navigate(['/comments/' + this.comment.postId]);
      },
      (error) => {
        this.snackBar.open('Update failed', 'Close', {duration: 5000})
      }
    )
  }

  getComment() {
    this.commentService.getComment(this.commentId).subscribe(resp => {
      this.comment = resp;
      this.oldContent = resp.content;
      console.log(resp);
    })
  }

  public getCreateErrorMessage(): string {
    if (this.contentForm.hasError('required')) {
      return 'Comment cannot be empty!'
    }

    return 'Comment must be at least 10 characters long!';
  }

  getLikers(): string {
    const usernames = this.comment.likes.map((like: any) => like.liker.userName);
    return usernames.join(', ');
  }
}
