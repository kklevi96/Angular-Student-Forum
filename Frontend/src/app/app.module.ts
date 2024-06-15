import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {ListSubjectsComponent} from './display-components/subject/list-subjects/list-subjects.component';
import {ListPostsComponent} from './display-components/post/list-posts/list-posts.component';
import {ListCommentsComponent} from './display-components/comment/list-comments/list-comments.component';
import {NavigationComponent} from './display-components/navigation/navigation.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MatSlideToggleModule} from "@angular/material/slide-toggle";
import {FooterComponent} from './display-components/footer/footer.component';
import {MatListModule} from "@angular/material/list";
import {MatButtonModule} from "@angular/material/button";
import {MatIconModule} from "@angular/material/icon";
import {MatMenuModule} from "@angular/material/menu";
import {HomeComponent} from './display-components/home/home.component';
import {HTTP_INTERCEPTORS, HttpClientModule} from "@angular/common/http";
import {RegisterComponent} from './auth/register/register.component';
import {MatInputModule} from "@angular/material/input";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {MatSnackBarModule} from "@angular/material/snack-bar";
import {MatFormFieldModule} from "@angular/material/form-field";
import {MatCheckboxModule} from "@angular/material/checkbox";
import {LoginComponent} from './auth/login/login.component';
import {LogoutComponent} from './auth/logout/logout.component';
import {AuthInterceptor} from "./auth/authconfig.interceptor";
import {LoggedInAsComponent} from './display-components/logged-in-as/logged-in-as.component';
import {MatExpansionModule} from "@angular/material/expansion";
import {UserProfileComponent} from './auth/user-profile/user-profile.component';
import {MatCardModule} from "@angular/material/card";
import {MatGridListModule} from "@angular/material/grid-list";
import {EditSubjectComponent} from './display-components/subject/edit-subject/edit-subject.component';
import {EditPostComponent} from './display-components/post/edit-post/edit-post.component';
import {EditCommentComponent} from './display-components/comment/edit-comment/edit-comment.component';
import {AddSubjectComponent} from './display-components/subject/add-subject/add-subject.component';
import {AddPostComponent} from './display-components/post/add-post/add-post.component';
import {AddCommentComponent} from './display-components/comment/add-comment/add-comment.component';
import {ListOneCommentComponent} from './display-components/comment/list-one-comment/list-one-comment.component';
import {MatToolbarModule} from "@angular/material/toolbar";
import {MatProgressSpinnerModule} from "@angular/material/progress-spinner";

@NgModule({
  declarations: [
    AppComponent,
    ListSubjectsComponent,
    ListPostsComponent,
    ListCommentsComponent,
    NavigationComponent,
    FooterComponent,
    HomeComponent,
    RegisterComponent,
    LoginComponent,
    LogoutComponent,
    LoggedInAsComponent,
    UserProfileComponent,
    EditSubjectComponent,
    EditPostComponent,
    EditCommentComponent,
    AddSubjectComponent,
    AddPostComponent,
    AddCommentComponent,
    ListOneCommentComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatSlideToggleModule,
    MatListModule,
    MatButtonModule,
    MatIconModule,
    MatMenuModule,
    HttpClientModule,
    MatInputModule,
    FormsModule,
    ReactiveFormsModule,
    MatSnackBarModule,
    MatFormFieldModule,
    MatCheckboxModule,
    MatExpansionModule,
    MatCardModule,
    MatGridListModule,
    MatToolbarModule,
    MatProgressSpinnerModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    },
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
