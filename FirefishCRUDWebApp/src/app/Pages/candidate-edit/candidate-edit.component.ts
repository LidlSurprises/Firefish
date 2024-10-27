import { Component } from '@angular/core';
import { Candidate, CandidateService } from '../../Services/candidate.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-candidate-edit',
  templateUrl: './candidate-edit.component.html',
  styleUrl: './candidate-edit.component.css'
})
export class CandidateEditComponent {
  candidate!: any;
  candidateId!: any;

  errors: any = [];
  isLoading: boolean = false; 
  loadingTitle: string = 'Loading';

  constructor(private route: ActivatedRoute, private candidateService: CandidateService) {

  }

  ngOnInit() {
    this.candidateId = this.route.snapshot.paramMap.get('id');

    this.candidateService.GetCandidate(this.candidateId).subscribe((response:any) => {
      this.candidate = response;
    });
  }

  UpdateCandidate() {
    this.isLoading = true; // Start loading
    this.loadingTitle = 'Saving';

    this.candidateService.UpdateCandidate(this.candidate).subscribe({
      next: (response: any) => {
        alert('Successfully Updated');
        this.isLoading = false;
      },
      error: (error: any) => {
        alert('Error Updating Candidate');
        this.isLoading = false;
      }
    });
  }

    FormatDate(date: Date): string {
    const year = date.getFullYear();
    const month = String(date.getMonth() + 1).padStart(2, '0'); // Months are 0-indexed
    const day = String(date.getDate()).padStart(2, '0');

    return `${year}-${month}-${day}`;
  }
}
