import {Component, OnInit, ViewChild} from '@angular/core';
import {Course} from '../../../models/course.model';
import {AdminService} from '../../admin.service';
import {NgForm} from '@angular/forms';

@Component({
  selector: 'app-start-semester',
  templateUrl: './start-semester.component.html',
  styleUrls: ['./start-semester.component.css']
})
export class StartSemesterComponent implements OnInit {
  @ViewChild('selectCourses') SelectCoursesForm: NgForm;
  courses: Course[];

  constructor(private aService: AdminService) { }

  ngOnInit(): void {
    this.courses = this.aService.coursesAvailable;
  }

  onSelectCourses(): void {
    for (const property in this.SelectCoursesForm.value.courses) {
      console.log(this.SelectCoursesForm.value.courses[property]);
    }
  }

}
