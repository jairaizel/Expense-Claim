import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

interface Claim {
  id: number;
  description: string;
  amount: number;
  status: string;
}

@Component({
  selector: 'app-claim-processing',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './claim-processing.component.html',
  styleUrls: ['./claim-processing.component.css']
})
export class ClaimProcessingComponent implements OnInit {
  claims: Claim[] = [];

  ngOnInit() {
    // Fetch claims from a service
    this.claims = [
      { id: 1, description: 'Office supplies', amount: 150.00, status: 'Approved' },
      { id: 2, description: 'Travel expenses', amount: 500.00, status: 'Approved' },
      { id: 3, description: 'Software license', amount: 300.00, status: 'Processed' },
    ];
  }

  processClaim(claimId: number) {
    // Implement claim processing logic here
    const claim = this.claims.find(c => c.id === claimId);
    if (claim) {
      claim.status = 'Processed';
    }
  }
}