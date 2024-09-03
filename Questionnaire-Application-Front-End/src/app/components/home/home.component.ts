import { Component } from '@angular/core';
import { Questionnaire } from '../../models/questionnaire/questionnaire.model';
import { QuestionnaireService } from '../../services/questionnaire/questionnaire.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  questionnaires: Questionnaire[] = [
    // {
    //   id: "33b2c0d8-c55b-4078-88af-5c44efeba936",
    //   title: "Q1",
    //   subTitle: "Introduction",
    //   description: "The Form serves as a comprehensive tool for capturing essential details about ...",
    //   published: false,
    // },
    // {
    //   id: "d8181147-7fc8-462a-9bac-b5a64f285389",
    //   title: "Q2",
    //   subTitle: "Build Up",
    //   description: "The Form serves as a comprehensive tool for capturing essential details about ...",
    //   published: true,
    // },
    // {
    //   id: "e6d2ba61-0b99-4c87-9b6a-53dbd60499c6",
    //   title: "Q3",
    //   subTitle: "Body",
    //   description: "The Form serves as a comprehensive tool for capturing essential details about ...",
    //   published: false,
    // },
    // {
    //   id: "b4fdf7c6-f558-4142-a766-9ad4b688b86e",
    //   title: "Q4",
    //   subTitle: "Conclusion",
    //   description: "The Form serves as a comprehensive tool for capturing essential details about ...",
    //   published: true,
    // },
  ];

  constructor(private questionnaireService: QuestionnaireService) {}

  ngOnInit() : void {
    this.questionnaireService.getQuestionnaires().subscribe((result: Questionnaire[]) => (this.questionnaires = result));
  }
}
