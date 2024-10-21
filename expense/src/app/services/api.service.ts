import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private baseUrl = 'http://localhost:5000/api'; // Update with your API port

  constructor(private http: HttpClient) { }

  // Auth
  login(username: string, password: string): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}/auth/login`, { username, password });
  }

  // Claims
  getClaims(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}/claims`);
  }

  createClaim(claim: any): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}/claims`, claim);
  }

  updateClaim(id: number, claim: any): Observable<any> {
    return this.http.put<any>(`${this.baseUrl}/claims/${id}`, claim);
  }

  deleteClaim(id: number): Observable<any> {
    return this.http.delete<any>(`${this.baseUrl}/claims/${id}`);
  }
}