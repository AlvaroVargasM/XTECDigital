import { Injectable } from '@angular/core';
import {Rubric} from '../models/rubric.model';
import {News} from '../models/news.model';
import {Group} from '../models/group.model';
import {Student} from '../models/student.model';

@Injectable({
  providedIn: 'root'
})
export class ProfessorService {
  /* COMS!
    Aca guardamos la informacion del professor que se encuentre en session actualmente
   */
  loggedProfessor: Student;

  /* COMS!
    Aca mostramos todos los grupos a los que el profesor en sesion actualmente este ensenhando
    esto para poder escoger uno en especifico para a session actual y traer informacion de solo un grupo
    fijarse en la manera que manejo os grupos en los modelos
   */
  groups: Group[];

  /* COMS!
    Este seria el grupo que escogimos
   */
  currentGroup: Group;

  /* COMS!
    Aca treriamos las rubricas del grupo que tengamos seleccionado
   */
  rubrics: Rubric[];

  /* COMS!
    Aca treriamos las noticias del grupo que tengamos seleccionado
   */
  news: News[];

  /* COMS!
    Aca treriamos los estudiantes del grupo que tengamos seleccionado
   */
  gStudents: Student[];

  /* COMS!
    Aca treriamos los numeros de equipos del grupo que tengamos seleccionado
    Aun no sabemos que otra informacion ocupariamos
   */
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
