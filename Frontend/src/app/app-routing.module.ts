import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {ListSubjectsComponent} from "./display-components/subject/list-subjects/list-subjects.component";
import {HomeComponent} from "./display-components/home/home.component";
import {RegisterComponent} from "./auth/register/register.component";
import {LoginComponent} from "./auth/login/login.component";
import {LogoutComponent} from "./auth/logout/logout.component";
import {ListPostsComponent} from "./display-components/post/list-posts/list-posts.component";
import {AuthGuard} from "./auth/auth.guard";
import {EditSubjectComponent} from "./display-components/subject/edit-subject/edit-subject.component";
import {AuthGuardAdmin} from "./auth/auth.guard.admin";
import {EditPostComponent} from "./display-components/post/edit-post/edit-post.component";
import {ListCommentsComponent} from "./display-components/comment/list-comments/list-comments.component";
import {EditCommentComponent} from "./display-components/comment/edit-comment/edit-comment.component";

const routes: Routes = [
  {path: 'home', component: HomeComponent},
  {path: 'subjects', component: ListSubjectsComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'login', component: LoginComponent},
  {path: 'logout', component: LogoutComponent},
  {path: 'posts/:subjectid', component: ListPostsComponent},
  {path: 'comments/:postid', component: ListCommentsComponent, canActivate: [AuthGuard]},
  {path: 'edit/subject/:subjectid', component: EditSubjectComponent, canActivate: [AuthGuardAdmin]},
  {path: 'edit/post/:postid', component: EditPostComponent, canActivate: [AuthGuard]},
  {path: 'edit/comment/:commentid', component: EditCommentComponent, canActivate: [AuthGuard]},
  {path: '**', component: ListSubjectsComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
