import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html'
})
export class ContactComponent {
  contactForm = {
    name: '',
    email: '',
    message: ''
  };

  constructor(private http: HttpClient) {}

  submitForm(): void {
    this.http.post('api/test/contact', this.contactForm).subscribe(response => {
      console.log(response);
    });
  }
}
