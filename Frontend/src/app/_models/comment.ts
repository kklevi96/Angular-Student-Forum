import {User} from "../auth/auth.service";

export class Comment {
  "id": string = ""
  "content": string = ""
  "timestamp": string = ""
  "lastEdited": string = ""
  "editCount": number = 0
  "siteUserId": string = ""
  "postId": string = ""
  "author": User
  "likes": string[];
}
