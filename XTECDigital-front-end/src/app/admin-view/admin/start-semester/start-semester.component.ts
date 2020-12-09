import {Component, OnInit, ViewChild} from '@angular/core';
import {Course} from '../../../models/course.model';
import {AdminService} from '../../admin.service';
import {NgForm} from '@angular/forms';
import {Semester} from '../../../models/semester.model';

@Component({
  selector: 'app-start-semester',
  templateUrl: './start-semester.component.html',
  styleUrls: ['./start-semester.component.css']
})
export class StartSemesterComponent implements OnInit {
  @ViewChild('createSemester') createSemesterForm: NgForm;
  @ViewChild('selectCourses') SelectCoursesForm: NgForm;
  step: number;
  coursesList: Course[];
  coursesChosen: Course[];
  selectedList: string[] = [];

  constructor(private aService: AdminService) {
    this.step = 1;
  }

  ngOnInit(): void {
    this.coursesList = this.aService.coursesAvailable;
    this.coursesChosen = this.aService.coursesActive;
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
    for (const property in this.SelectCoursesForm.value.courses) {
      if (this.SelectCoursesForm.value.courses[property]) {
        this.selectedList.push(property.toString());
      }
    }

    /* COMS!
      Esta lista de codigos es de los cursos escogidos, se deberia enviar
     */
    console.log(this.selectedList);
  }



}
