import {User} from "../auth/auth.service";
import {Comment} from "./comment";

export class Post {
  "id": string = ""
  "content": string = ""
  "timestamp": string = ""
  "lastEdited": string = ""
  "editCount": number = 0
  "siteUserId": string = ""
  "subjectCode": string = ""
  "author": User
  "comments": Comment[]
}
