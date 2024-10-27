import { Component } from '@angular/core';
import { Candidate, CandidateService } from '../../Services/candidate.service';

@Component({
  selector: 'app-candidate-page',
  templateUrl: './candidate-page.component.html',
  styleUrl: './candidate-page.component.css'
})
export class CandidatePageComponent {
  isLoading: boolean = false;
  candidates!: Candidate[]
  constructor(private candidateService: CandidateService) {

  }

  ngOnInit() {
    this.GetCandidates()
  }

  GetCandidates() {
    this.isLoading = true;
    this.candidateService.GetCandidates().subscribe((response: any) => {
      this.candidates = response
      console.log(this.candidates);
      this.isLoading = false;
    });
  }

  DeleteCandidate(event: any, candidateId: any) {
    if (confirm('Are you sure you want to delete the Candidate?')){
      event.target.innerText = "Deleting...";

      this.candidateService.DeleteCandidate(candidateId).subscribe((response: any) => {
        this.GetCandidates();

      });
    }
  }
}
