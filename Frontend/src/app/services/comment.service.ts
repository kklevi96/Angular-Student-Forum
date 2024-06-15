import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Comment} from "../_models/comment";


@Injectable({
  providedIn: 'root'
})
export class CommentService {
  http: HttpClient
  comments: Comment[]

  constructor(http: HttpClient) {
    this.http = http;
    this.comments = [];
  }

  getComments(postId: string) {
    return this.http
      .get<Comment[]>('https://localhost:7015/api/CommentsApi/GetCommentsofPost/' + postId);
  }

  getComment(commentId: string) {
    return this.http
      .get<Comment>('https://localhost:7015/api/CommentsApi/Details/' + commentId);
  }

  editComment(commentId: string, comment: Comment) {
    return this.http.put('https://localhost:7015/api/CommentsApi/Edit/' + commentId, comment)
  }

  deleteComment(commentId: string) {
    return this.http.delete('https://localhost:7015/api/CommentsApi/Delete/' + commentId);
  }

  addComment(commentToBeAdded: Comment) {
    return this.http.post<Comment>('https://localhost:7015/api/CommentsApi/Create/', commentToBeAdded);
  }

  toggleLike(commentId: string) {
    return this.http.post('https://localhost:7015/api/CommentLikeApi/ToggleLike/' + commentId, null);
  }

  isLiked(commentId: string) {
    return this.http.get<boolean>('https://localhost:7015/api/CommentLikeApi/IsLiked/' + commentId);
  }
}
