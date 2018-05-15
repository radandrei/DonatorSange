import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const appRoutes: Routes = [
  { path: 'register', component: RegistrationFormComponent },
  { path: 'login', component: LoginFormComponent },
  {path:'patient',component:PatientPageComponent},
  {path:'patient-appointment',component:PatientAppointmentPage},
  {path:"**",component:LoginFormComponent}
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);