import { Course } from './../models/course.model';
import { Injectable } from '@angular/core';
import { CommunicationService } from '../communication.service';
import {Professor} from '../models/professor.model';
import {Student} from '../models/student.model';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  isStartSemester: boolean;
  fd: FormData = new FormData();

  // COURSE MANAGEMENT

  /* COMS!
    Esta lista se rellena con los cursos disponibles [courses] de la base de datos,
    el manejo de la info de cursos se puede ver en los modelos
   */
  public coursesAvailable: any;

  // START SEMESTER
  coursesActive: Course[] = [];

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

  constructor(private comService:CommunicationService) {
    // this.coursesAvailable = [
    //   new Course(
    //     'CE3101',
    //     'Bases de Datos',
    //     4,
    //     'Ingenieria en Computadores'),
    //   new Course(
    //     'CE2201',
    //     'Laboratorio de Circuitos Electricos',
    //     1,
    //     'Ingenieria en Computadores'),
    //   new Course(
    //     'EL2207',
    //     'Elementos Activos',
    //     4,
    //     'Ingenieria en Electronica'
    //   )
    // ];
    comService.getCourses().then(res=>{
      this.coursesAvailable = res;
      console.log(this.coursesAvailable);
      
    })
    
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
