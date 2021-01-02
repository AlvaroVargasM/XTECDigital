import { Injectable } from '@angular/core';
import {Rubric} from '../models/rubric.model';
import {News} from '../models/news.model';
import {Group} from '../models/group.model';
import {Student} from '../models/student.model';

@Injectable({
  providedIn: 'root'
})
export class ProfessorService {
  currentGroup: Group;
  groups: Group[];
  rubrics: Rubric[];
  news: News[];
  gStudents: Student[];
  teamsNumbers: number[];

  constructor() {
    this.currentGroup = null;
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
    this.news = [
      new News(
        '',
        'Ya esta el segundo quiz',
        'Ya se encuentra disponible la evaluacion del quiz #2',
        '20-12-2019'
      ),
      new News(
        '',
        'Se atrasa la tarea',
        'La tarea que estaba para este lunes se va a mover hasta nuevo asviso por motivos personales',
        '18-9-2020'
      )
    ];
    this.groups = [
      new Group(
        '4',
        '2020',
        'V',
        'CE3101'
      ),
      new Group(
        '2',
        '2020',
        '1',
        'CE3101'
      )
    ];
  }
}
