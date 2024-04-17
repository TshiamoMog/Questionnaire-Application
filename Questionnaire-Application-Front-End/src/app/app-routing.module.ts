import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/users/login/login.component';
import { RegistrationComponent } from './components/users/registration/registration.component';
import { ResetPasswordComponent } from './components/users/forgot-password/reset-password/reset-password.component';
import { HomeComponent } from './components/home/home.component';
import { AddQuestionnaireComponent } from './components/questionnaires/add-questionnaire/add-questionnaire.component';
import { ForgotPasswordComponent } from './components/users/forgot-password/forgot-password.component';
import { SendTokenComponent } from './components/users/forgot-password/send-token/send-token.component';
import { NewPasswordComponent } from './components/users/forgot-password/new-password/new-password.component';

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
  path: 'forgot-password',
  component: ForgotPasswordComponent,
},
{
  path: 'send-token',
  component: SendTokenComponent,
},
{
  path: 'reset-password',
  component: ResetPasswordComponent,
},
{
  path: 'new-password',
  component: NewPasswordComponent,
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
