import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { AdminComponent } from './admin-view/admin/admin.component';
import { ProfessorComponent } from './professor-view/professor/professor.component';
import { StudentComponent } from './student-view/student/student.component';
import { LoginComponent } from './home-view/login/login.component';
import { RouterModule, Routes } from '@angular/router';
import {FormsModule} from '@angular/forms';

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
    LoginComponent
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
