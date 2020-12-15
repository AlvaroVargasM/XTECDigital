import { Injectable } from '@angular/core';
import {Course} from '../models/course.model';
import {Professor} from '../models/professor.model';
import {Student} from '../models/student.model';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  isStartSemester: boolean;

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

  studentsList: Student[];

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

    this.professorsList = [
      new Professor(
        '123654987',
        'San Toñito',
        'agonzalest@itcr.ac.cr'
      ),
      new Professor(
        '456123789',
        'El Nog',
        'nog@itcr.ac.cr'
      )
    ];

    this.studentsList = [
      new Student(
        '2018085151',
        'Alvaro Vargas',
        'valvaro707@gmail.com',
        '85787059'
      ),
      new Student(
        '2016085151',
        'Joey Molina',
        'upupup@gmail.com',
        '96528453'
      )
    ];
  }
}
