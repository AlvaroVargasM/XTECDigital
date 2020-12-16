import { Component, OnInit } from '@angular/core';
import {Rubric} from '../../models/rubric.model';
import {ProfessorService} from '../professor.service';

@Component({
  selector: 'app-professor',
  templateUrl: './professor.component.html',
  styleUrls: ['./professor.component.css']
})
export class ProfessorComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
