//https://stackoverflow.com/questions/41684114/easy-way-to-make-a-confirmation-dialog-in-angular

import {Component, OnInit} from '@angular/core';
import {MatSnackBar} from '@angular/material/snack-bar';
import {PostService} from '../../../services/post.service';
import {CommentService} from '../../../services/comment.service';
import {ActivatedRoute} from '@angular/router';
import {AuthService} from '../../../auth/auth.service';
import {Comment} from '../../../_models/comment';
import {Post} from "../../../_models/post";

@Component({
  selector: 'app-list-comments',
  templateUrl: './list-comments.component.html',
  styleUrls: ['./list-comments.component.scss']
})
export class ListCommentsComponent implements OnInit {
  postId: string = '';
  comments!: Comment[];
  post: Post = new Post();
  snackBar: MatSnackBar
  showCreateForm: boolean = false;

  constructor(
    private postService: PostService,
    private commentService: CommentService,
    private route: ActivatedRoute,
    public authService: AuthService,
    snackBar: MatSnackBar
  ) {
    this.snackBar = snackBar;
  }

  ngOnInit(): void {
    const routeParams = this.route.snapshot.paramMap;
    this.postId = String(routeParams.get('postid'));
    this.getPost();
    this.getComments();
  }

  getComments() {
    this.commentService.getComments(this.postId).subscribe(response => {
      this.comments = response.sort((a, b) => {
        return new Date(a.timestamp).getTime() - new Date(b.timestamp).getTime();
      });
    });
  }

  getPost() {
    this.postService.getPost(this.postId).subscribe(response => {
      this.post = response;
    });
  }

  deleteComment(commentId: string) {
    if (confirm("Are you sure to delete the comment?")) {
      this.commentService.deleteComment(commentId).subscribe(
        success => {
          this.snackBar.open('Delete was successful', 'Close', {duration: 5000});
          this.getComments();
        },
        error => {
          this.snackBar.open('Delete failed', 'Close', {duration: 5000});
        }
      );
    }
  }

  addClicked() {
    this.showCreateForm = false;
    this.getComments();
  }

}
