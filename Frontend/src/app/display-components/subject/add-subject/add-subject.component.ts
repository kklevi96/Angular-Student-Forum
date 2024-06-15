//https://stackoverflow.com/questions/45057907/input-type-number-only-numeric-value-validation

import {Component, EventEmitter, Output} from '@angular/core';
import {MatSnackBar} from "@angular/material/snack-bar";
import {FormControl, Validators} from "@angular/forms";
import {SubjectService} from "../../../services/subject.service";
import {Subject} from "../../../_models/subject";
import {Router} from "@angular/router";

@Component({
  selector: 'app-add-subject',
  templateUrl: './add-subject.component.html',
  styleUrls: ['./add-subject.component.scss']
})
export class AddSubjectComponent {
  router: Router;
  snackBar: MatSnackBar;
  subjectCodeForm: FormControl;
  subjectNameForm: FormControl;
  subjectCreditForm: FormControl;
  subjectSemesterForm: FormControl;
  subjectToCreate: Subject = new Subject();
  @Output() addClicked = new EventEmitter();
  @Output() cancelClicked = new EventEmitter();


  constructor(private subjectService: SubjectService, snackBar: MatSnackBar, router: Router) {
    this.snackBar = snackBar;
    this.subjectCodeForm = new FormControl('', Validators.required);
    this.subjectNameForm = new FormControl('', [Validators.required, Validators.maxLength(100)]);
    this.subjectCreditForm = new FormControl('', [Validators.required, Validators.min(0), Validators.max(30), Validators.pattern("^[0-9]*$")]);
    this.subjectSemesterForm = new FormControl('', [Validators.required, Validators.min(0), Validators.max(7), Validators.pattern("^[0-9]")]);
    this.router = router;
  }


  public getSubjectCodeErrorMessage(): string {
    return 'Subject must have a (Neptun) ID'
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

  addSubject() {
    this.subjectService.addSubject(this.subjectToCreate)
      .subscribe(
        success => {
          this.snackBar.open('Subject added', 'Close', {duration: 5000});
          this.subjectToCreate = new Subject();
          this.router.navigate(['home'])
        },
        error => {
          this.snackBar.open('Subject add failed', 'Close', {duration: 5000});
        }
      );
  }

  onAddSubject() {
    this.addSubject();
    this.router.navigate(['/home']);
    this.addClicked.emit();
  }

  cancel() {
    this.subjectToCreate = new Subject();
    this.cancelClicked.emit();
  }
}
