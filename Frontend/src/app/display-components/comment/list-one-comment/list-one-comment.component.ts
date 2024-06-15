import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {Comment} from '../../../_models/comment'
import {AuthService} from "../../../auth/auth.service";
import {CommentService} from "../../../services/comment.service";

@Component({
  selector: 'app-list-one-comment',
  templateUrl: './list-one-comment.component.html',
  styleUrls: ['./list-one-comment.component.scss']
})
export class ListOneCommentComponent implements OnInit {
  @Input() comment!: Comment
  @Output() deleteClicked = new EventEmitter();

  public isLiked!: boolean;

  constructor(public authService: AuthService, private commentService: CommentService) {
  }

  onDeleteComment() {
    this.deleteClicked.emit();
  }

  getIsLiked() {
    this.commentService.isLiked(this.comment.id)
      .subscribe(resp => {
        this.isLiked = resp;
      });
  }

  getComment() {
    this.commentService.getComment(this.comment.id)
      .subscribe(resp => {
        this.comment = resp;
      })
  }

  toggleLike() {
    this.commentService.toggleLike(this.comment.id)
      .subscribe(() => {
        this.getIsLiked();
        this.getComment();
      });
  }

  ngOnInit(): void {
    this.getIsLiked();
  }
}
