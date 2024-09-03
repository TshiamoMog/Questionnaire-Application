import { Component } from '@angular/core';
import { User } from './models/user/user.model';
import { UserService } from './services/user/user.service';
import { Questionnaire } from './models/questionnaire/questionnaire.model';
import { QuestionnaireService } from './services/questionnaire/questionnaire.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Questionnaire-Application-Front-End';
  users: User[] = [];
  questionnaires: Questionnaire[] = [];

  constructor(private userService: UserService, private questionnaireService: QuestionnaireService) {}

  ngOnInit() : void {
    // this.userService.getUsers().subscribe((result: User[]) => (this.users = result));
    // this.questionnaireService.getQuestionnaires().subscribe((result: Questionnaire[]) => (this.questionnaires = result))
    // console.log(this.users);
    
  }
}
