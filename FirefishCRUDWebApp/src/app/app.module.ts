import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomePageComponent } from './Pages/home-page/home-page.component';
import { AboutPageComponent } from './Pages/about-page/about-page.component';
import { ContactPageComponent } from './Pages/contact-page/contact-page.component';
import { NavbarComponent } from './Pages/Partials/navbar/navbar.component';
import { CandidateCreateComponent } from './Pages/candidate-create/candidate-create.component';
import { CandidateService } from './Services/candidate.service';
import { LoaderComponent } from './Pages/Partials/loader/loader.component';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatInputModule } from '@angular/material/input';
import { MatNativeDateModule } from '@angular/material/core';
import { CandidatePageComponent } from './Pages/candidate-page/candidate-page.component';
import { CandidateEditComponent } from './Pages/candidate-edit/candidate-edit.component';




@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    AboutPageComponent,
    ContactPageComponent,
    NavbarComponent,
    CandidateCreateComponent,
    LoaderComponent,
    CandidatePageComponent,
    CandidateEditComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    CommonModule,
    MatDatepickerModule,
    MatInputModule,
    MatNativeDateModule
  ],
  providers: [CandidateService, provideAnimationsAsync()],
  bootstrap: [AppComponent]
})
export class AppModule { }
