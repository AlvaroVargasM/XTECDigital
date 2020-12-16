import { Injectable } from '@angular/core';
import {Rubric} from '../models/rubric.model';

@Injectable({
  providedIn: 'root'
})
export class ProfessorService {
  rubrics: Rubric[];

  constructor() {
    this.rubrics = [
      new Rubric(
        'Quices',
        30
      ),
      new Rubric(
        'Examenes',
        30
      ),
      new Rubric(
        'Proyectos',
        40
      )
    ];
  }
}
