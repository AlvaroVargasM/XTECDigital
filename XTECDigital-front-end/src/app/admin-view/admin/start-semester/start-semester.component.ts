import {Component, OnDestroy, OnInit, ViewChild} from '@angular/core';
import {Course} from '../../../models/course.model';
import {AdminService} from '../../admin.service';
import {NgForm} from '@angular/forms';
import {Semester} from '../../../models/semester.model';
import {Professor} from '../../../models/professor.model';
import {Student} from '../../../models/student.model';

@Component({
  selector: 'app-start-semester',
  templateUrl: './start-semester.component.html',
  styleUrls: ['./start-semester.component.css']
})

/**
 * This component is in charge of starting a new semester
 */
export class StartSemesterComponent implements OnInit{
  @ViewChild('createSemester') createSemesterForm: NgForm;
  @ViewChild('selectCourses') selectCoursesForm: NgForm;
  @ViewChild('selectGroups') selectGroupsForm: NgForm;
  @ViewChild('selectProfessors') selectProfessorsForm: NgForm;
  @ViewChild('selectStudents') selectStudentsForm: NgForm;

  step: number;
  coursesList: Course[];
  coursesChosen: Course[];
  selectedCoursesCodesList: string[] = [];
  professors: Professor[];
  students: Student[];

  profes: { course: string, plist: string[] };

  constructor(private aService: AdminService) {
    this.step = 1;
  }

  ngOnInit(): void {
    this.coursesList = this.aService.coursesAvailable;
    this.coursesChosen = this.aService.coursesActive;
    this.professors = this.aService.professorsList;
    this.students = this.aService.studentsList;
  }

  onCreateSemester(): void {
    this.step++;

    /* COMS!
      Esta informacion se refiere a la del nuevo semestre, se deberia enviar este objeto
      AUN NO ESTA DEFINIDO SI SE ENVIARA POR PARTES O SI SE ENVIARA EN UNA SOLO POST
     */
    console.log(this.createSemesterForm.value);
  }

  onSelectCourses(): void {
    this.step++;

    for (const property in this.selectCoursesForm.value.courses) {
      if (this.selectCoursesForm.value.courses[property]) {
        this.selectedCoursesCodesList.push(property.toString());
      }
    }

    /* COMS!
      Esta lista de codigos es de los cursos escogidos para el semestre escogio del paso 1
     */
    console.log(this.selectedCoursesCodesList);

    for (let code of this.selectedCoursesCodesList) {
      for (let course of this.coursesList) {
        if (code === course.code) {
          this.aService.coursesActive.push(
            new Course(
              course.code,
              course.name,
              course.credits,
              course.career));
        }
      }
    }
  }

  onSelectGroups(): void {
    this.step++;

    /* COMS!
      Aca deberiamos mandar los numero de grupo para los cursos que van a ser escogidos en el paso anterior
     */
    console.log(this.selectGroupsForm.value);
  }

  onSelectProfessors(): void {
    this.step++;

    /* COMS!
      Aca deberiamos mandar las cedulas de los profes que van a ensehar los cursos seleccionados
     */
    for (const course in this.selectProfessorsForm.value) {
      console.log([course].toString());
      for (const professor in this.selectProfessorsForm.value[course]) {
        if (this.selectProfessorsForm.value[course][professor]) {
          console.log([professor].toString());
        }
      }
    }
  }

  onSelectStudents(): void {
    this.step = 1;

    /* COMS!
      Aca mandamos de manera similar a como mandamos los profes, el
      codigo del curso y los carnet de los estudiantes asociados a dicho codigo
     */
    for (const course in this.selectStudentsForm.value) {
      console.log([course].toString());
      for (const student in this.selectStudentsForm.value[course]) {
        if (this.selectStudentsForm.value[course][student]) {
          console.log([student].toString());
        }
      }
    }

    this.aService.coursesActive = [];
  }
}
