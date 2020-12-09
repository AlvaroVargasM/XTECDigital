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
  newSemester: Semester;
  coursesList: Course[];
  coursesChosen: Course[];

  constructor(private aService: AdminService) {
    this.step = 1;
  }

  ngOnInit(): void {
    this.coursesList = this.aService.coursesAvailable;
    this.coursesChosen = this.aService.coursesActive;
  }

  onCreateSemester(): void {
    this.step++;
    this.ngOnInit();
  }

  onSelectCourses(): void {
    for (const property in this.SelectCoursesForm.value.courses) {
      console.log(this.SelectCoursesForm.value.courses[property]);
    }
  }



}
