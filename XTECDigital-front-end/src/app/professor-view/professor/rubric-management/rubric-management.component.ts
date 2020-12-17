import {Component, OnInit, ViewChild} from '@angular/core';
import {Rubric} from '../../../models/rubric.model';
import {ProfessorService} from '../../professor.service';
import {NgForm} from '@angular/forms';
import {toNumbers} from '@angular/compiler-cli/src/diagnostics/typescript_version';

@Component({
  selector: 'app-rubric-management',
  templateUrl: './rubric-management.component.html',
  styleUrls: ['./rubric-management.component.css']
})
export class RubricManagementComponent implements OnInit {
  @ViewChild('modifyRubric') modifyRubricForm: NgForm;
  currentRubrics: Rubric[];
  isModify: boolean;
  isDelete: boolean;
  arr: Array<number>;
  isAdd: boolean;

  constructor(private pService: ProfessorService) {
    this.isModify = false;
    this.isDelete = false;
    this.isAdd = false;
  }

  ngOnInit(): void {
    this.currentRubrics = this.pService.rubrics;
  }

  onModify(): void {
    this.isModify = true;
    this.ngOnInit();
  }

  onAdd(): void {
    this.isModify = true;
    this.isAdd = true;
    this.ngOnInit();
  }

  onDelete(): void {
    this.arr = new Array<number>(this.currentRubrics.length - 1);

    this.isModify = true;
    this.isDelete = true;
    this.ngOnInit();
  }

  onSaveRubrics(): void {
    this.isModify = false;
    this.isDelete = false;
    this.isAdd = false;

    console.log(this.modifyRubricForm.value);

    this.modifyRubricForm.reset();
    this.ngOnInit();
  }

}
