import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-claim-creation',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './claim-creation.component.html',
  styleUrls: ['./claim-creation.component.css']
})
export class ClaimCreationComponent {
  claimDescription: string = '';
  claimAmount: number | null = null;
  claimDepartment: string = '';
  file: File | null = null;

  departments: string[] = [
    'Computer Science',
    'Engineering',
    'Business Administration',
    'Mathematics',
    'Physics'
  ];

  onFileSelected(event: any) {
    this.file = event.target.files[0];
  }

  submitClaim() {
    if (this.claimDescription && this.claimAmount && this.claimDepartment && this.file) {
      // Here you would call your service to send the claim data to the backend
      console.log('Claim submitted:', {
        description: this.claimDescription,
        amount: this.claimAmount,
        department: this.claimDepartment,
        file: this.file.name
      });
      alert('Claim submitted successfully!');
      this.resetForm();
    } else {
      alert('Please fill out all fields and upload a receipt.');
    }
  }

  resetForm() {
    this.claimDescription = '';
    this.claimAmount = null;
    this.claimDepartment = '';
    this.file = null;
  }
}