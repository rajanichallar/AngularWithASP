import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { FormControl, Validators } from '@angular/forms';
import { BouncyObjects } from '../../DTOs/calObjects';
import { NgZone } from '@angular/core';
import { ChangeDetectorRef } from '@angular/core';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html'
})
export class AboutComponent implements OnInit {
  aboutInfo: any;
  sum: number = 0;
  squareSum: number = 0;
  evenSum: number = 0;
  oddSum: number = 0;
  inputValue: string = '';
  threesSum: number = 0;
  mNProduct: number = 0;
  mNSum: number = 0;
  mult3or5: boolean = false;
  sumNotMult3or5: number = 0;
  sumOfEndsWith3or5: number = 0;
  isBouncy: boolean = false;
  sumOfBouncy: BouncyObjects = { Sum: 0, Bouncy: [] };
  // numberFormControl = new FormControl('', [Validators.required]);
  constructor(private http: HttpClient, private zone: NgZone, private cdr: ChangeDetectorRef) { }

  ngOnInit(): void {
    this.http.get<any>('api/test/about/GetInfo', {
      headers: { 'Accept': 'application/json' }
    }).subscribe(data => {
      this.aboutInfo = data;
      console.log('aboutInfo', data)
    });

    // this.http.get('api/test/about/GetStatus', {
    //   headers: { 'Accept': 'application/json' }
    // }).subscribe(response => {
    //   console.log(response);
    // });

    // this.http.get<WeatherForecast>('api/test/weatherforecast/GetByDay?daysAhead=3')
    //   .subscribe(data => console.log('days', data));

    // this.http.get<WeatherForecast>('api/test/weatherforecast/GetInfo')
    //   .subscribe(data => console.log('data', data));
  }
  calculateSum(): void {
    const value = Number(this.inputValue);
    if (value && !isNaN(value)) {
      this.sum = (value * (value + 1)) / 2; // (n(n+1))/2
    }
  }
  calculateSquareSum(): void {
    const value = Number(this.inputValue);
    if (value && !isNaN(value)) {
      this.squareSum = (value * (value + 1) * (2 * value + 1)) / 6; //(n(n+1)(2*n+1))/6
    }
  }
  calculateEvenSum() {
    const value = Number(this.inputValue);
    var count = 0;
    if (value && !isNaN(value)) {
      // const count = Math.floor(value / 2);
      // this.evenSum = count * (count + 1); //Sum =𝑘(𝑘+1),where 𝑘=𝑛/2
      //or
      //even numbers  
      this.evenSum = 0;
      for (let i = 1; i <= value; i++) {
        if (i % 2 == 0) {
          this.evenSum += i;
        }
      }
    }

  }
  calculateOddSum() {
    const value = Number(this.inputValue);
    var count = 0;
    if (value && !isNaN(value)) {
      // const count = Math.floor(value / 2);
      // this.evenSum = count * (count + 1); //Sum =𝑘(𝑘+1),where 𝑘=𝑛/2
      //or
      //odd numbers  
      this.oddSum = 0;
      for (let i = 1; i <= value; i++) {
        if (i % 2 > 0) {
          this.oddSum += i;
        }
      }
    }
  }
  calculateThreesSum() {
    if (!isNaN(Number(this.inputValue))) {
      const params = new HttpParams().set('number', this.inputValue);
      this.http.get<number>('api/test/about/GetSumOfCountByThrees', { params })
        .subscribe(data => {
          this.threesSum = data;
        });
    }
  }
  calculateMNSum() {
    if (this.inputValue) {
      const params = new HttpParams().set('stringNum', this.inputValue);
      this.http.get<number>('api/test/about/calculateMNSum', { params })
        .subscribe(data => {
          this.mNSum = data;
        });
    }
  }
  calculateMNProduct() {
    if (this.inputValue) {
      const params = new HttpParams().set('stringNum', this.inputValue);
      this.http.get<number>('api/test/about/calculateMNProduct', { params })
        .subscribe(data => this.mNProduct = data);
    }
  }
  calculateMult3or5() {
    if (this.inputValue) {
      const params = new HttpParams().set('number', Number(this.inputValue));
      this.http.get<boolean>('api/test/about/calculateMult3or5', { params })
        .subscribe(data => this.mult3or5 = data);
    }
  }
  calculateSumOfNotMult3or5() {
    if (this.inputValue) {
      const params = new HttpParams().set('number', Number(this.inputValue));
      this.http.get<number>('api/test/about/calculateSumOfNotMult3or5', { params })
        .subscribe(data => this.sumNotMult3or5 = data);
    }
  }
  clearInput() {
    this.inputValue = '';
    this.sum = this.squareSum = this.evenSum = this.mNProduct = this.mNSum = this.oddSum = this.squareSum = 0;

  }
  calculateSumEndsWith3or5() {
    if (this.inputValue) {
      const params = new HttpParams().set('number', Number(this.inputValue));
      this.http.get<number>('api/test/about/calculateSumOfEndsWith3or5', { params })
        .subscribe(data => this.sumOfEndsWith3or5 = data);
    }
  }
  calculateIsBouncy() {
    if (this.inputValue) {
      const params = new HttpParams().set('number', Number(this.inputValue));
      this.http.get<boolean>('api/test/about/calculateIsBouncy', { params })
        .subscribe(data => this.isBouncy = data);
    }
  }
  calculateSumOfBouncy() {
    if (this.inputValue) {
      const params = new HttpParams().set('stringNum', this.inputValue);
      this.http.get<BouncyObjects>('api/test/about/calculateSumOfBouncy', { params })
        .subscribe(data => {
          this.zone.run(() => {
            this.sumOfBouncy = data;
            console.log('data:', this.sumOfBouncy);
            this.cdr.detectChanges(); // Force view update
          });
        });
    }
  }
}
interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}