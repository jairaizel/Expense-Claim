import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { ClaimCreationComponent } from './claim-creation/claim-creation.component';
import { ClaimStatusComponent } from './claim-status/claim-status.component';
import { ClaimApprovalComponent } from './claim-approval/claim-approval.component';
import { ClaimProcessingComponent } from './claim-processing/claim-processing.component';

export const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'home', component: HomeComponent },
  { path: 'claim-create', component: ClaimCreationComponent },
  { path: 'claim-status', component: ClaimStatusComponent },
  { path: 'claim-approve', component: ClaimApprovalComponent },
  { path: 'claim-process', component: ClaimProcessingComponent }
];