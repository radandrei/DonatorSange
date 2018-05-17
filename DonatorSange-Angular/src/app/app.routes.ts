import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RegistrationFormComponent } from './registration-form/registration-form.component';
import { LoginFormComponent } from './login-form/login-form.component';
import { DoctorComponent } from './doctor/doctor.component';
import { MedicalstaffComponent } from './medicalstaff/medicalstaff.component';
import { DonorComponent } from './donor/donor.component';


const appRoutes: Routes = [
  { path: 'register', component: RegistrationFormComponent },
  { path: 'login', component: LoginFormComponent },
  { path: 'donor', component:  DonorComponent},
  { path: 'doctor', component: DoctorComponent },
  { path: 'medicalstaff', component: MedicalstaffComponent },
  {path:"**",component:LoginFormComponent}
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);