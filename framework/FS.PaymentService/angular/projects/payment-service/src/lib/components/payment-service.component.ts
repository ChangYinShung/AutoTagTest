import { Component, OnInit } from '@angular/core';
import { PaymentServiceService } from '../services/payment-service.service';

@Component({
  selector: 'lib-payment-service',
  template: ` <p>payment-service works!</p> `,
  styles: [],
})
export class PaymentServiceComponent implements OnInit {
  constructor(private service: PaymentServiceService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
