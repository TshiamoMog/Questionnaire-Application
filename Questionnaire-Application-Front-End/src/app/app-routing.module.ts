import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/users/login/login.component';
import { RegistrationComponent } from './components/users/registration/registration.component';
import { ResetPasswordComponent } from './components/users/reset-password/reset-password.component';
import { HomeComponent } from './components/home/home.component';
import { AddQuestionnaireComponent } from './components/add-questionnaire/add-questionnaire.component';

const routes: Routes = [{
  path: '',
  redirectTo: 'login',
  pathMatch: 'full',
},
{
  path: 'login',
  component: LoginComponent,
},
{
  path: 'register',
  component: RegistrationComponent,
},
{
  path: 'reset-password',
  component: ResetPasswordComponent,
},
{
  path: 'home',
  component: HomeComponent,
},
{
  path: 'create-questionnaire',
  component: AddQuestionnaireComponent,
}];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
