import { Injectable } from '@angular/core';
import {Course} from '../models/course.model';
import {Professor} from '../models/professor.model';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  // COURSE MANAGEMENT

  /* COMS!
    Esta lista se rellena con los cursos disponibles de la base de datos,
    el manejo de los cursos se puede ver en los modelos
   */
  coursesAvailable: Course[];

  // START SEMESTER

  /* COMS!
    Esta lista se rellena con los cursos que se asociaron al semestre que se posteo en el pase anterios
    del form en la base de datos, el manejo de los cursos se puede ver en los modelos
   */
  coursesActive: Course[];

  professorsList: Professor[];

  constructor() {
    this.coursesAvailable = [
      new Course(
        'CE3101',
        'Bases de Datos',
        4,
        'Ingenieria en Computadores'),
      new Course(
        'CE2201',
        'Laboratorio de Circuitos Electricos',
        1,
        'Ingenieria en Computadores'),
      new Course(
        'EL2207',
        'Elementos Activos', 4,
        'Ingenieria en Electronica'
      )
    ];
    this.coursesActive = this.coursesAvailable;
  }
}
