import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon'
import { LoginComponent } from './components/users/login/login.component';
import { RegistrationComponent } from './components/users/registration/registration.component';
import { GoogleLoginCardComponent } from './components/helpers/google-login-card/google-login-card.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ResetPasswordComponent } from './components/users/forgot-password/reset-password/reset-password.component';
import { HomeComponent } from './components/home/home.component';
import { HeaderComponent } from './components/helpers/header/header.component';
import { AddQuestionnaireComponent } from './components/questionnaires/add-questionnaire/add-questionnaire.component';
import { ForgotPasswordComponent } from './components/users/forgot-password/forgot-password.component';
import { SendTokenComponent } from './components/users/forgot-password/send-token/send-token.component';
import { NewPasswordComponent } from './components/users/forgot-password/new-password/new-password.component';
import { UserCardComponent } from './components/helpers/user-card/user-card.component';
import { HttpClientModule } from '@angular/common/http';
import { MyQuestionnaireComponent } from './components/questionnaires/my-questionnaire/my-questionnaire.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegistrationComponent,
    GoogleLoginCardComponent,
    ResetPasswordComponent,
    HomeComponent,
    HeaderComponent,
    AddQuestionnaireComponent,
    ForgotPasswordComponent,
    SendTokenComponent,
    NewPasswordComponent,
    UserCardComponent,
    MyQuestionnaireComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    MatInputModule,
    MatFormFieldModule,
    MatIconModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
  ],
  providers: [
    provideAnimationsAsync()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
