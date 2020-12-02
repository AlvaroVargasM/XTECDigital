import {Component, OnInit, ViewChild} from '@angular/core';
import {AdminService} from '../../admin.service';
import {Course} from '../../../models/course.model';
import {NgForm} from '@angular/forms';

@Component({
  selector: 'app-course-management',
  templateUrl: './course-management.component.html',
  styleUrls: ['./course-management.component.css']
})
export class CourseManagementComponent implements OnInit {
  @ViewChild('newCourse') newCourseForm: NgForm;
  courses: Course[];

  constructor(private aService: AdminService) { }

  ngOnInit(): void {
    this.courses = this.aService.coursesAvailable;
  }

  onCreateCourse(): void {
    console.log(this.newCourseForm.value.name);
  }
}
