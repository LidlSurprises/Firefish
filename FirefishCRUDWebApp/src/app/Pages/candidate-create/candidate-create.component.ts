import { Component } from '@angular/core';
import { Candidate, CandidateService } from '../../Services/candidate.service'

@Component({
  selector: 'app-candidate-create',
  templateUrl: './candidate-create.component.html',
  styleUrl: './candidate-create.component.css'
})
export class CandidateCreateComponent {
  forename!: string;
  surname!: string;
  dateOfBirth!: string;
  address1!: string;
  town!: string;
  country!: string;
  postCode!: string;
  phoneHome!: string;
  phoneMobile!: string;
  phoneWork!: string;

  errors: any = [];
  isLoading: boolean = false;
  loadingTitle: string = 'Loading';

  constructor(private candidateService: CandidateService) {

  }

  saveCandidate() {
    this.loadingTitle = 'Saving';
    this.isLoading = true;
    var candidate = {
      id: 0,
      forename: this.forename,
      surname: this.surname,
      dateOfBirth: this.dateOfBirth,
      address1: this.address1,
      town: this.town,
      country: this.country,
      postCode: this.postCode,
      phoneHome: this.phoneHome,
      phoneMobile: this.phoneMobile,
      phoneWork: this.phoneWork
    };

    this.candidateService.AddCandidate(candidate).subscribe({
      next: (response: any) => {
        console.log(response, 'response');
        alert('Sucessfully created candidate');
        this.forename = '';
        this.surname = '';
        this.dateOfBirth = '';
        this.address1 = '';
        this.town = '';
        this.country = '';
        this.postCode = '';
        this.phoneHome = '';
        this.phoneMobile = '';
        this.phoneWork = '';
      },
      error: (error: any) => {
        this.errors = error.error.errors;
        alert('Error Adding Candidate')
        console.log(error, 'errors');
      }
    });
    this.isLoading = false;
  }
}
