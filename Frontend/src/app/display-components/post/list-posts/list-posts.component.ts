import {Component, OnInit} from '@angular/core';
import {Post} from "../../../_models/post";
import {PostService} from "../../../services/post.service";
import {ActivatedRoute} from "@angular/router";
import {CommentService} from "../../../services/comment.service";
import {SubjectService} from "../../../services/subject.service";
import {AuthService} from "../../../auth/auth.service";
import {MatSnackBar} from "@angular/material/snack-bar";

@Component({
  selector: 'app-list-posts',
  templateUrl: './list-posts.component.html',
  styleUrls: ['./list-posts.component.scss']
})
export class ListPostsComponent implements OnInit {

  subjectId: string = ''
  posts!: Post[]
  subjectName: string = ''
  snackBar: MatSnackBar
  showCreateForm: boolean = false;
  post: Post = new Post();


  constructor(
    private subjectService: SubjectService,
    private postService: PostService,
    private commentService: CommentService,
    private route: ActivatedRoute,
    public authService: AuthService,
    snackBar: MatSnackBar) {
    this.snackBar = snackBar;
  }

  ngOnInit(): void {
    const routeParams = this.route.snapshot.paramMap;
    this.subjectId = String(routeParams.get('subjectid'))
    this.getSubjectName();
    this.getPosts();
  }

  getPosts() {
    this.postService.getPosts(this.subjectId).subscribe(response => {
      this.posts = response.sort((a, b) => {
        return new Date(a.timestamp).getTime() - new Date(b.timestamp).getTime();
      });
      this.posts.forEach(post => {
        this.commentService.getComments(post.id).subscribe(commentsResponse => {
          post.comments = commentsResponse;
        })
      })
    });
  }

  getSubjectName() {
    this.subjectService.getSubjectDetails(this.subjectId).subscribe(response => {
      this.subjectName = response.name;
    })
  }

  deletePost(postId: string) {
    if (confirm("Are you sure to delete the post? All comments under the post will also be deleted and will not be recoverable.")) {
      this.postService.deletePost(postId).subscribe(
        (success) => {
          this.snackBar.open('Delete was successful', 'Close', {duration: 5000});
          this.getPosts()
        },
        (error) => {
          this.snackBar.open('Delete failed', 'Close', {duration: 5000});
        }
      );
    }
  }

  addClicked() {
    this.showCreateForm = false;
    this.getPosts();
  }
}

