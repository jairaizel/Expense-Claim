import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ApiService } from '../services/api.service';

interface Claim {
  id: number;
  description: string;
  amount: number;
  submittedDate: Date;
  status: string;
}

@Component({
  selector: 'app-claim-status',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './claim-status.component.html',
  styleUrls: ['./claim-status.component.css']
})
export class ClaimStatusComponent implements OnInit {
  claims: Claim[] = [];

  constructor(private apiService: ApiService) {}

  ngOnInit() {
    this.fetchClaims();
  }

  fetchClaims() {
    this.apiService.getClaims().subscribe({
      next: (claims: Claim[]) => {
        this.claims = claims;
      },
      error: (error) => {
        console.error('Error fetching claims:', error);
        // Handle error (e.g., show an error message to the user)
      }
    });
  }

  getStatusClass(status: string): string {
    switch (status.toLowerCase()) {
      case 'approved':
        return 'status-approved';
      case 'pending':
        return 'status-pending';
      case 'processed':
        return 'status-processed';
      default:
        return 'status-default';
    }
  }
}