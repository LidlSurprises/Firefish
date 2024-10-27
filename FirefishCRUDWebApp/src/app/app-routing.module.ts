import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from './Pages/home-page/home-page.component';
import { AboutPageComponent } from './Pages/about-page/about-page.component';
import { ContactPageComponent } from './Pages/contact-page/contact-page.component';
import { CandidatePageComponent } from './Pages/candidate-page/candidate-page.component';
import { CandidateCreateComponent } from './Pages/candidate-create/candidate-create.component';
import { CandidateEditComponent } from './Pages/candidate-edit/candidate-edit.component';

const routes: Routes = [
  {path: '', component: HomePageComponent, title: 'Home Page'},
  {path: 'about-us', component: AboutPageComponent, title: 'About Us'},
  {path: 'contact-us', component: ContactPageComponent, title: 'Contact Us'},
  {path: 'candidate', component: CandidatePageComponent, title: 'Candidate Creation'},
  {path: 'candidate/create', component: CandidateCreateComponent, title: 'Candidate Create'},
  {path: 'candidate/:id/edit', component: CandidateEditComponent, title: 'Candidate Edit'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
