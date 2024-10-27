import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Candidate {
  id?: number | null;
  forename: string;
  surname: string;
  dateOfBirth: any;
  address1: string;
  town: string;
  country: string;
  postCode: string;
  phoneHome: string;
  phoneMobile: string;
  phoneWork: string;
}

@Injectable({
  providedIn: 'root'
})

export class CandidateService {
  private apiUrl = 'http://localhost:5282/candidates';

  constructor(private http: HttpClient) {
  }

  GetCandidates() {
    return this.http.get<Candidate>(this.apiUrl);
  }

  GetCandidate(candidateId: number) {
    return this.http.get<Candidate>(`${this.apiUrl}/${candidateId}`);
  }

  AddCandidate(candidate: Candidate) {
    candidate.dateOfBirth = this.FormatDate(new Date(candidate.dateOfBirth as string));

    return this.http.post(this.apiUrl, candidate);
  }

  UpdateCandidate(candidate: Candidate) {
    candidate.dateOfBirth = this.FormatDate(new Date(candidate.dateOfBirth as string));

    return this.http.put(`${this.apiUrl}/${candidate.id}`, candidate);
  }

  DeleteCandidate(candidateId: number) {
    return this.http.delete(`${this.apiUrl}/${candidateId}`);
  }

  FormatDate(date: Date): string {
    const year = date.getFullYear();
    const month = String(date.getMonth() + 1).padStart(2, '0'); // Months are 0-indexed
    const day = String(date.getDate()).padStart(2, '0');

    return `${year}-${month}-${day}`;
  }

}
