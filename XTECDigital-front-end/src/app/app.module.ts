import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { AdminComponent } from './admin-view/admin/admin.component';
import { ProfessorComponent } from './professor-view/professor/professor.component';
import { StudentComponent } from './student-view/student/student.component';
import { LoginComponent } from './home-view/login/login.component';
import { RouterModule, Routes } from '@angular/router';
import {FormsModule} from '@angular/forms';
import { CourseManagementComponent } from './admin-view/admin/course-management/course-management.component';
import { StartSemesterComponent } from './admin-view/admin/start-semester/start-semester.component';
import { UploadSemesterComponent } from './admin-view/admin/upload-semester/upload-semester.component';
import {RubricManagementComponent} from './professor-view/professor/rubric-management/rubric-management.component';
import { NewsManagementComponent } from './professor-view/professor/news-management/news-management.component';
import { AssignEvaluationComponent } from './professor-view/professor/assign-evaluation/assign-evaluation.component';


const appRoutes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'admin', component: AdminComponent},
  { path: 'professor', component: ProfessorComponent},
  { path: 'student', component: StudentComponent}
];

@NgModule({
  declarations: [
    AppComponent,
    AdminComponent,
    ProfessorComponent,
    StudentComponent,
    LoginComponent,
    CourseManagementComponent,
    StartSemesterComponent,
    UploadSemesterComponent,
    RubricManagementComponent,
    NewsManagementComponent,
    AssignEvaluationComponent
  ],
  imports: [
    BrowserModule,
    RouterModule,
    RouterModule.forRoot(appRoutes),
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
