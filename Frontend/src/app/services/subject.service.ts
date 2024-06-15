import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Subject} from "../_models/subject";

@Injectable({
  providedIn: 'root'
})
export class SubjectService {
  http: HttpClient
  subjects: Subject[]

  constructor(http: HttpClient) {
    this.http = http
    this.subjects = []
  }

  getSubjects() {
    return this.http
      .get<Subject[]>('https://localhost:7015/api/SubjectsApi');
  }

  getSubjectDetails(subjectId: string) {
    return this.http.get<Subject>('https://localhost:7015/api/SubjectsApi/Details/' + subjectId);
  }

  editSubject(subjectId: string, subjectToBeUpdated: Subject) {
    return this.http.put<Subject>('https://localhost:7015/api/SubjectsApi/Edit/' + subjectId, subjectToBeUpdated);
  }

  addSubject(subjectToBeCreated: Subject) {
    return this.http.post<Subject>('https://localhost:7015/api/SubjectsApi/Create/', subjectToBeCreated);
  }

  deleteSubject(idToBeDeleted: string) {
    return this.http.delete('https://localhost:7015/api/SubjectsApi/Delete/' + idToBeDeleted);
  }
}
