import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Post} from "../_models/post";

@Injectable({
  providedIn: 'root'
})
export class PostService {
  http: HttpClient
  posts: Post[]

  constructor(http: HttpClient) {
    this.http = http
    this.posts = [];
  }

  getPosts(subjectId: string) {
    return this.http
      .get<Post[]>('https://localhost:7015/api/PostsApi/GetPostsofSubject/' + subjectId);
  }

  getPost(postId: string) {
    return this.http
      .get<Post>('https://localhost:7015/api/PostsApi/Details/' + postId);
  }

  editPost(postId: string, post: Post) {
    return this.http.put('https://localhost:7015/api/PostsApi/Edit/' + postId, post)
  }

  deletePost(postId: string) {
    return this.http.delete('https://localhost:7015/api/PostsApi/Delete/' + postId);
  }

  addPost(postToBeAdded: Post) {
    return this.http.post<Post>('https://localhost:7015/api/PostsApi/Create/', postToBeAdded);
  }

}
