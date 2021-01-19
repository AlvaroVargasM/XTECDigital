import {Component, OnInit, ViewChild} from '@angular/core';
import {NgForm} from '@angular/forms';
import {Rubric} from '../../../models/rubric.model';
import {ProfessorService} from '../../professor.service';

@Component({
  selector: 'app-assign-evaluation',
  templateUrl: './assign-evaluation.component.html',
  styleUrls: ['./assign-evaluation.component.css']
})
export class AssignEvaluationComponent implements OnInit {
  @ViewChild('createEvaluation') createEvaluationForm: NgForm;
  @ViewChild('createGroup') createGroupForm: NgForm;
  currentRubrics: Rubric[];
  defaultType = 1;
  specificationFile = null;

  constructor(private pService: ProfessorService) { }

  ngOnInit(): void {
    this.currentRubrics = this.pService.rubrics;
  }

  onCreateEvaluation(): void {
    console.log(this.createEvaluationForm.value);
  }

  onSelectSpecification(event): void {
    this.specificationFile = event.target.files[0];
  }
}
