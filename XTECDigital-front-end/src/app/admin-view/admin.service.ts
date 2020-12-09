import { Injectable } from '@angular/core';
import {Course} from '../models/course.model';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  // COURSE MANAGEMENT

  coursesAvailable: Course[];

  // START SEMESTER

  coursesActive: Course[];

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
  }
}
