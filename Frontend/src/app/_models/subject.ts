import {Post} from "./post";

export class Subject {
  "subjectCode": string = ""
  "name": string = ""
  "creditValue": number = 0
  "examSubject": boolean = false
  "semester": number = 0
  "posts": Post[]
}
