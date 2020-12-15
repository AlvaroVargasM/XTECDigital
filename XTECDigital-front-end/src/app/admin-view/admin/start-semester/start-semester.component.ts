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
export class StartSemesterComponent implements OnInit{
  @ViewChild('createSemester') createSemesterForm: NgForm;
  @ViewChild('selectCourses') selectCoursesForm: NgForm;
  @ViewChild('selectGroups') selectGroupsForm: NgForm;
  @ViewChild('selectProfessors') selectProfessorsForm: NgForm;
  @ViewChild('selectStudents') selectStudentsForm: NgForm;

  step: number;
  coursesList: Course[];
  coursesChosen: Course[];
  selectedCoursesList: string[] = [];
  professors: Professor[];
  students: Student[];

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
     */
    console.log(new Semester(this.createSemesterForm.value.year, this.createSemesterForm.value.period).period);

    this.ngOnInit();
  }

  onSelectCourses(): void {
    this.step++;

    for (const property in this.selectCoursesForm.value.courses) {
      if (this.selectCoursesForm.value.courses[property]) {
        this.selectedCoursesList.push(property.toString());
      }
    }

    /* COMS!
      Esta lista de codigos es de los cursos escogidos, se deberia enviar
     */
    console.log(this.selectedCoursesList);
  }

  onSelectGroups(): void {
    this.step++;
  }

  onSelectProfessors(): void {
    this.step++;
  }

  onSelectStudents(): void {
    this.step = 1;
  }
}
