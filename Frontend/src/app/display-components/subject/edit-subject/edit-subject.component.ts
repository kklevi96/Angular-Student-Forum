import {Component, OnInit} from '@angular/core';
import {Subject} from "../../../_models/subject";
import {AuthService} from "../../../auth/auth.service";
import {SubjectService} from "../../../services/subject.service";
import {ActivatedRoute, Router} from "@angular/router";
import {MatSnackBar} from "@angular/material/snack-bar";
import {PostService} from "../../../services/post.service";
import {FormControl, Validators} from "@angular/forms";


@Component({
  selector: 'app-edit-subject',
  templateUrl: './edit-subject.component.html',
  styleUrls: ['./edit-subject.component.scss']
})
export class EditSubjectComponent implements OnInit {
  subjectId: string = '';
  subject!: Subject;
  snackBar: MatSnackBar;
  subjectNameForm: FormControl;
  subjectCreditForm: FormControl;
  subjectSemesterForm: FormControl;
  oldSubject: Subject = new Subject();


  constructor(private subjectService: SubjectService, private postsService: PostService, private route: ActivatedRoute, public authService: AuthService, snackBar: MatSnackBar, public router: Router) {
    this.snackBar = snackBar;
    this.subjectNameForm = new FormControl('', [Validators.required, Validators.maxLength(100)]);
    this.subjectCreditForm = new FormControl('', [Validators.required, Validators.min(0), Validators.max(30), Validators.pattern("^[0-9]*$")]);
    this.subjectSemesterForm = new FormControl('', [Validators.required, Validators.min(0), Validators.max(7), Validators.pattern("^[0-9]")]);
  }


  ngOnInit(): void {
    const routeParams = this.route.snapshot.paramMap;
    this.subjectId = String(routeParams.get('subjectid'));
    this.getSubject();
  }

  editSubject() {
    this.subjectService.editSubject(this.subjectId, this.subject).subscribe(
      (success) => {
        this.snackBar.open('Update was successful!', 'Close', {duration: 5000})
        this.router.navigate(['/subjects'])
      },
      (error) => {
        this.snackBar.open('Update failed', 'Close', {duration: 5000})
      }
    )
  }

  getSubject() {
    this.subjectService.getSubjectDetails(this.subjectId).subscribe(resp => {
      this.subject = resp;
      this.oldSubject.name = resp.name;
      this.oldSubject.creditValue = resp.creditValue;
      this.oldSubject.semester = resp.semester;
      this.oldSubject.examSubject = resp.examSubject;
    });
  }


  public getSubjectNameErrorMessage(): string {
    if (this.subjectNameForm.hasError('required')) {
      return 'Subject must have a name'
    }
    return 'Subject name is at most 100 characters long'
  }

  public getSubjectCreditValueErrorMessage(): string {
    if (this.subjectCreditForm.hasError('required')) {
      return 'The credit value of the subject must be defined'
    }
    if (this.subjectCreditForm.hasError('min')) {
      return 'The credit value cannot be less than zero'
    }
    if (this.subjectCreditForm.hasError('max')) {
      return 'The subject can worth at most 30 credits'
    }
    if (this.subjectSemesterForm.hasError('pattern'))
      return 'Only numbers are allowed';
    return 'Unknown error';
  }

  public getSubjectSemesterErrorMessage(): string {
    if (this.subjectSemesterForm.hasError('required')) {
      return 'The recommended semester of the subject must be defined'
    }
    if (this.subjectSemesterForm.hasError('min')) {
      return 'The semester value cannot be earlier than the 0th'
    }
    if (this.subjectSemesterForm.hasError('max')) {
      return 'The recommended semester value is at most the 7th'
    }
    if (this.subjectSemesterForm.hasError('pattern'))
      return 'Only numbers are allowed';

    return 'Unknown error'
  }
}
