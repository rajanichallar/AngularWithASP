import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-status',
  templateUrl: './status.component.html',
  styleUrls: ['./status.component.css']
})
export class StatusComponent {
constructor(private http: HttpClient) {}
 public status = '/status'; // Use proxy or full URL if needed
  ngOnInit(): void {
    this.http.get('api/test/status').subscribe(data => {
       return this.http.get(this.status);
    });
  }
}
