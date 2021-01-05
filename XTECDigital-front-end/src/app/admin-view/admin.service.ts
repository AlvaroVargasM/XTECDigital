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
    Esta lista se rellena con los cursos disponibles [courses] de la base de datos,
    el manejo de la info de cursos se puede ver en los modelos
   */
  coursesAvailable: Course[];

  // START SEMESTER

  /* COMS!
    Esta lista se rellena con los cursos asociados entre el semestre del paso 1 y los cursos del paso 2
    de la seccion de inicializacion de semestre, osea los cursos que se encontrarian en [isAvailable]
    en la base de datos. Esto en buena teoria pues aun se tiene que definir como se va a enviar el form
    de inicializacion. ESTO IGNORARLO HASTA QUE SE RESUELVA.
   */
  coursesActive: Course[];

  /* COMS!
    Esta es la lista de todos los professores disponibles en el sistema, esta info sale de la base no relacional
    fijarse en la forma que manejo modelo professor
   */
  professorsList: Professor[];

  /* COMS!
    Esta es la lista de todos los estudiantes disponibles en el sistema, esta info sale de la base no relacional
    fijarse en la forma que manejo modelo estudiante
   */
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
        'Elementos Activos',
        4,
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
