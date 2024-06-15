import {Component} from '@angular/core';
import {Post} from "../../../_models/post";
import {MatSnackBar} from "@angular/material/snack-bar";
import {PostService} from "../../../services/post.service";
import {ActivatedRoute, Router} from "@angular/router";
import {AuthService} from "../../../auth/auth.service";
import {FormControl, Validators} from "@angular/forms";

@Component({
  selector: 'app-edit-post',
  templateUrl: './edit-post.component.html',
  styleUrls: ['./edit-post.component.scss']
})
export class EditPostComponent {
  postId: string = '';
  post!: Post;
  snackBar: MatSnackBar;
  contentForm: FormControl;
  oldContent: string = '';


  constructor(private postService: PostService, private route: ActivatedRoute, public authService: AuthService, snackBar: MatSnackBar, public router: Router) {
    this.snackBar = snackBar;
    this.contentForm = new FormControl('', [Validators.required, Validators.minLength(10)]);
    this.router = router;

  }


  ngOnInit(): void {
    const routeParams = this.route.snapshot.paramMap;
    this.postId = String(routeParams.get('postid'));
    this.getPost();

  }

  editPost() {
    this.postService.editPost(this.postId, this.post).subscribe(
      (success) => {
        this.snackBar.open('Update was successful!', 'Close', {duration: 5000})
        this.router.navigate(['/posts/' + this.post.subjectCode]);
      },
      (error) => {
        this.snackBar.open('Update failed', 'Close', {duration: 5000})
      }
    )
  }

  getPost() {
    this.postService.getPost(this.postId).subscribe(resp => {
      this.post = resp;
      this.oldContent = resp.content;
    })
  }

  public getUpdateErrorMessage(): string {
    if (this.contentForm.hasError('required')) {
      return 'Post cannot be empty!'
    }

    return 'Post must be at least 10 characters long!';
  }
}
