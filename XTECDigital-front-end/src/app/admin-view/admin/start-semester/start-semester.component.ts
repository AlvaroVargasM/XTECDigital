import {Component, OnDestroy, OnInit, ViewChild} from '@angular/core';
import {Course} from '../../../models/course.model';
import {AdminService} from '../../admin.service';
import {NgForm} from '@angular/forms';
import {Semester} from '../../../models/semester.model';
import {Professor} from '../../../models/professor.model';
import {Student} from '../../../models/student.model';
import { CommunicationService } from 'src/app/communication.service';

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
  public coursesList;
  coursesChosen: Course[];
  selectedCoursesCodesList: string[] = [];
  professors: Professor[];
  students: Student[];

  profes: { course: string, plist: string[] };

  constructor(private aService: AdminService, private comService: CommunicationService) {
    this.step = 1;
  }

  ngOnInit(): void {
    // this.comService.getCourses().then(res=>{
    //   this.coursesList = res;
    //   console.log(res);
    // })
    this.coursesList = this.aService.coursesAvailable;
    console.log(this.coursesList );
    
    this.coursesChosen = this.aService.coursesActive;
    this.professors = this.aService.professorsList;
    this.students = this.aService.studentsList;
  }

  onCreateSemester(): void {
    this.step++;

    //console.log(this.createSemesterForm.value);

    this.aService.fd.append(
      'semester',
      '{period:' + this.createSemesterForm.value.period + ',year:' + this.createSemesterForm.value.year + '}'
    );
    console.log(this.aService.fd.getAll('semester'));
  }

  onSelectCourses(): void {
    this.step++;

    for (const property in this.selectCoursesForm.value.courses) {
      if (this.selectCoursesForm.value.courses[property]) {
        this.selectedCoursesCodesList.push(property.toString());
      }
    }

    let fdcourses = '';
    for (let c of this.selectedCoursesCodesList) {
      fdcourses += c + ',';
    }
    this.aService.fd.append('courses', fdcourses);
    console.log(this.aService.fd.getAll('courses'));

    //console.log(this.selectedCoursesCodesList);

    for (let code of this.selectedCoursesCodesList) {
      for (let course of this.coursesList) {
        if (code === course.code) {
          this.aService.coursesActive.push(
            new Course(
              course.code,
              course.name,
              course.credits,
              course.school));
        }
      }
    }
  }

  onSelectGroups(): void {
    this.step++;

    //console.log(this.selectGroupsForm.value.courses);

    let fdcoursesnumbers = '';

    for (let course in this.selectGroupsForm.value) {
      for (let number in this.selectGroupsForm.value[course])
      fdcoursesnumbers += this.selectGroupsForm.value[course][number].toString() + ',';
    }

    this.aService.fd.append('groups', fdcoursesnumbers);
    console.log(this.aService.fd.getAll('groups'));
  }

  onSelectProfessors(): void {
    this.step++;
    let fdteachers = '';

    for (const course in this.selectProfessorsForm.value) {
      for (const professor in this.selectProfessorsForm.value[course]) {
        if (this.selectProfessorsForm.value[course][professor]) {
          fdteachers += [professor].toString() + ',';
        }
      }
      fdteachers += ';';
    }

    this.aService.fd.append('professors', fdteachers);
    console.log(this.aService.fd.getAll('professors'));
  }

  onSelectStudents(): void {
    this.step = 1;
    let fdstudents = '';

    for (const course in this.selectStudentsForm.value) {
      for (const student in this.selectStudentsForm.value[course]) {
        if (this.selectStudentsForm.value[course][student]) {
          fdstudents += [student].toString() + ',';
        }
      }
      fdstudents += ';';
    }

    this.aService.fd.append('students', fdstudents);
    console.log(this.aService.fd.getAll('students'));
    this.aService.coursesActive = [];
  }
}
